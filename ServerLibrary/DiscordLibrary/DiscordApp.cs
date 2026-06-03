using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.DBModels;
using Server.Envir;
using Server.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiscordLibrary
{
    public class DiscordApp
    {
        private static readonly DiscordApp Instance = new DiscordApp();
        public static DiscordApp GetApp() => Instance;

        private static DiscordSocketClient _client;
        private static ulong connectionChannelID;
        private static ulong serverStatusChannelID;
        private static ulong globalChatChannelID;

        private static string token = string.Empty;
        private static string globalWebhook = string.Empty;
        private static string unusedWebhook = string.Empty;
        private static ulong guildId = 0;

        public async Task Run()
        {
            var config = LoadConfiguration("DiscordConfig.json");

            token = config["BotToken"]?.ToString() ?? string.Empty;
            connectionChannelID = ulong.Parse(config["ChannelIDs"]?["ConnectionChannelID"]?.ToString() ?? "0");
            serverStatusChannelID = ulong.Parse(config["ChannelIDs"]?["ServerStatusChannelID"]?.ToString() ?? "0");
            globalChatChannelID = ulong.Parse(config["ChannelIDs"]?["GlobalChatChannelID"]?.ToString() ?? "0");
            globalWebhook = config["Webhooks"]?["GlobalWebhook"]?.ToString() ?? string.Empty;
            unusedWebhook = config["Webhooks"]?["UnusedWebhook"]?.ToString() ?? string.Empty;
            guildId = ulong.Parse(config["GuildID"]?.ToString() ?? "0");

            var discordConfig = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.GuildMembers | GatewayIntents.GuildMessages | GatewayIntents.MessageContent,
                UseInteractionSnowflakeDate = false,
            };

            _client = new DiscordSocketClient(discordConfig);
            _client.Log += Log;
            _client.Ready += OnClientReady;
            _client.MessageReceived += MessageReceived;
            _client.SlashCommandExecuted += SlashCommandHandler;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private JObject LoadConfiguration(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(path))
            {
                var defaultConfig = new JObject
                {
                    ["BotToken"] = "",
                    ["ChannelIDs"] = new JObject
                    {
                        ["ConnectionChannelID"] = "",
                        ["ServerStatusChannelID"] = "",
                        ["GlobalChatChannelID"] = ""
                    },
                    ["Webhooks"] = new JObject
                    {
                        ["GlobalWebhook"] = "",
                        ["UnusedWebhook"] = ""
                    },
                    ["GuildID"] = ""
                };

                File.WriteAllText(path, defaultConfig.ToString());
            }

            using StreamReader file = File.OpenText(path);
            using JsonTextReader reader = new JsonTextReader(file);
            return (JObject)JToken.ReadFrom(reader);
        }

        private static Task Log(LogMessage msg)
        {
            SEnvir.Log($"[Discord] {msg}");
            return Task.CompletedTask;
        }

        private async Task OnClientReady()
        {
            SEnvir.Log("Discord Bot is active");

            if (guildId == 0) return;

            var commands = new SlashCommandBuilder()
                .WithName("nexusmir")
                .WithDescription("Contains all bot integration for NexusMir server.")
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("link")
                    .WithDescription("Links your Discord account to your NexusMir account.")
                    .WithType(ApplicationCommandOptionType.SubCommand)
                    .AddOption("link-code", ApplicationCommandOptionType.Integer, "Your link code (use @Link ingame)", isRequired: true));

            try
            {
                await _client.Rest.CreateGuildCommand(commands.Build(), guildId);
            }
            catch (HttpException exception)
            {
                string json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                SEnvir.Log(json);
            }
        }

        private static async Task SlashCommandHandler(SocketSlashCommand command)
        {
            if (command.Data.Name == "nexusmir")
                await HandleCommands(command);
        }

        private static async Task HandleCommands(SocketSlashCommand command)
        {
            var author = command.User;
            string subCommand = command.Data.Options.FirstOrDefault()?.Name ?? string.Empty;

            if (subCommand != "link")
                return;

            if (command.Data.Options.FirstOrDefault()?.Options.FirstOrDefault()?.Value is not long rawCode)
            {
                await command.RespondAsync("Invalid link code.", ephemeral: true);
                return;
            }

            if (rawCode > ushort.MaxValue || rawCode < 1)
            {
                await command.RespondAsync("Invalid link code.", ephemeral: true);
                return;
            }

            AccountInfo account = SEnvir.FindAccountByDiscordCode((ushort)rawCode, author.Id);
            if (account == null)
            {
                await command.RespondAsync("Failed to link accounts. Make sure the code is correct and your account is logged in.", ephemeral: true);
                return;
            }

            UpdateRole(author.Id, false, 1310105163574280312);

            if (!string.IsNullOrWhiteSpace(account.LastCharacter?.CharacterName))
                await UpdatePlayerNickname(account.LastCharacter.CharacterName, author.Id);

            var successEmbedBuilder = new EmbedBuilder()
                .WithTitle("Accounts Linked!")
                .WithDescription("Your account was successfully linked.")
                .WithColor(Color.Purple)
                .WithCurrentTimestamp();

            await command.RespondAsync(embed: successEmbedBuilder.Build(), ephemeral: true);
        }

        public static Task ServerOnline() => SendMessageToDiscordAsync(MessageType.ServerStatus, "Server Online");
        public static Task ServerOffline() => SendMessageToDiscordAsync(MessageType.ServerStatus, "Server Offline");
        public static Task ServerRebooting() => SendMessageToDiscordAsync(MessageType.ServerStatus, "Server Rebooting");

        public static Task PlayerConnected(string playerName, int userCount)
        {
            string message = userCount == 1
                ? $"{playerName} has logged in. There is now {userCount} player online!"
                : $"{playerName} has logged in. There are now {userCount} players online!";

            return SendMessageToDiscordAsync(MessageType.Connection, message);
        }

        public static Task PlayerDisconnected(string playerName, int userCount)
        {
            string message = userCount == 0
                ? $"{playerName} has logged out. The server is now barren."
                : userCount == 1
                    ? $"{playerName} has logged out. There is now {userCount} player online!"
                    : $"{playerName} has logged out. There are now {userCount} players online!";

            return SendMessageToDiscordAsync(MessageType.Connection, message);
        }

        public static async Task SendMessageToDiscordAsync(MessageType type, string message)
        {
            if (_client == null || _client.ConnectionState != ConnectionState.Connected)
                return;

            ulong channelId = type switch
            {
                MessageType.ServerStatus => serverStatusChannelID,
                MessageType.Global => globalChatChannelID,
                MessageType.Connection => connectionChannelID,
                _ => 0
            };

            if (channelId == 0) return;
            if (_client.GetChannel(channelId) is not IMessageChannel channel) return;

            await channel.SendMessageAsync(message);
        }

        public static void GlobalMessage(int mirClass, int mirGender, string playerName, string message)
        {
            string imageURL = GetAvatar(mirClass, mirGender);

            int colonIndex = message.IndexOf(':');
            if (colonIndex == -1) return;

            string output = message[(colonIndex + 1)..].Replace("(Global)", "").Trim();
            if (string.IsNullOrWhiteSpace(output)) return;

            if (output.Contains("@everyone", StringComparison.OrdinalIgnoreCase)) return;
            if (output.Contains("@here", StringComparison.OrdinalIgnoreCase)) return;

            output = EscapeJsonString(output);

            using WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");

            string payload = $"{{\"content\":\"{output}\",\"username\":\"{EscapeJsonString(playerName)}\",\"avatar_url\":\"{imageURL}\"}}";

            try
            {
                client.UploadData(globalWebhook, Encoding.UTF8.GetBytes(payload));
            }
            catch (WebException ex)
            {
                SEnvir.Log($"[DiscordWebhook] {ex.Message}");
            }
        }

        private static string EscapeJsonString(string value)
        {
            StringBuilder escapedBuilder = new StringBuilder();

            foreach (char c in value)
            {
                switch (c)
                {
                    case '"':
                        escapedBuilder.Append("\\\"");
                        break;
                    case '\\':
                        escapedBuilder.Append("\\\\");
                        break;
                    case '\b':
                        escapedBuilder.Append("\\b");
                        break;
                    case '\f':
                        escapedBuilder.Append("\\f");
                        break;
                    case '\n':
                        escapedBuilder.Append("\\n");
                        break;
                    case '\r':
                        escapedBuilder.Append("\\r");
                        break;
                    case '\t':
                        escapedBuilder.Append("\\t");
                        break;
                    default:
                        escapedBuilder.Append(c);
                        break;
                }
            }

            return escapedBuilder.ToString();
        }

        public static string GetAvatar(int mirClass, int mirGender)
        {
            if (mirClass == 0 && mirGender == 0) return "https://media.discordapp.net/attachments/1047983287139827873/1255981747955564704/1400.jpg?ex=667f1ba7&is=667dca27&hm=fcf83c80ae6e184e40651a4f81379172343dbcf0fc181134e8d7a99f9e2961f0&=&format=webp";
            if (mirClass == 0 && mirGender == 1) return "https://media.discordapp.net/attachments/1047983287139827873/1255981769832923236/1410.jpg?ex=667dca2c&is=667dca2c&hm=88ccd34aea4f288396380b1dbcca32b6250c2f2e4a110fe92155193fbac778d1&=&format=webp";
            if (mirClass == 1 && mirGender == 0) return "https://media.discordapp.net/attachments/1047983287139827873/1255981748169211985/1401.jpg?ex=667fc467&is=667e72e7&hm=2f6edb62bd8a49c5164c4723719cd0e6300b4c879cb01d8bebfecdf2a2f57a0e&=&format=webp";
            if (mirClass == 1 && mirGender == 1) return "https://media.discordapp.net/attachments/1047983287139827873/1255981770059550750/1411.jpg?ex=667fc46c&is=667e72ec&hm=464eaa813b78856d38c62ff101efd31818e0abaf8130b2974c968627a6151c40&=&format=webp";
            if (mirClass == 2 && mirGender == 0) return "https://media.discordapp.net/attachments/1047983287139827873/1255981748357959881/1402.jpg?ex=667fc467&is=667e72e7&hm=78166435a4f6d2480067b8a3e0bdbd8aac5dc159b55315643efd6179e12590c8&=&format=webp";
            if (mirClass == 2 && mirGender == 1) return "https://media.discordapp.net/attachments/1047983287139827873/1255981770365730836/1412.jpg?ex=667fc46d&is=667e72ed&hm=4a2de1567c9abb105926fb24832a26e8953bd67d318631825534d4120cba22b7&=&format=webp";
            return string.Empty;
        }

        public enum MessageType
        {
            ServerStatus,
            Connection,
            General,
            Global,
            MobDrop,
            MobSpawn
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Channel.Id != globalChatChannelID) return;
            if (message.Author.IsBot) return;

            if (message.Author is SocketGuildUser guildUser)
            {
                string sender = guildUser.Nickname ?? guildUser.GlobalName ?? guildUser.Username;

                foreach (PlayerObject player in SEnvir.Players)
                    player.Connection?.ReceiveChat($"(Discord) {sender}: {message.CleanContent}", Library.MessageType.Discord);

                SEnvir.LogChat($"(Discord) {sender}: {message.CleanContent}");
            }
        }

        public static async Task UpdatePlayerNickname(string name, ulong discordID)
        {
            if (_client?.GetGuild(guildId) is not SocketGuild guild) return;
            SocketGuildUser discordUser = guild.GetUser(discordID);

            try
            {
                if (discordUser == null || discordUser.Nickname == name) return;

                await discordUser.ModifyAsync(properties => properties.Nickname = name);
                SEnvir.Log($"Successfully updated {discordUser.Username}'s nickname to {name}.");
            }
            catch (Exception ex)
            {
                SEnvir.Log($"Failed to update nickname of DiscordID ({discordID}): {ex.Message}");
            }
        }

        internal static void UpdateRole(ulong discordID, bool remove, ulong roleID)
        {
            if (_client?.GetGuild(guildId) is not SocketGuild guild) return;
            SocketGuildUser discordUser = guild.GetUser(discordID);
            if (discordUser == null) return;

            var requestOptions = new RequestOptions
            {
                RetryMode = RetryMode.AlwaysRetry,
                AuditLogReason = "Ingame Linking."
            };

            try
            {
                if (remove)
                    _ = discordUser.RemoveRoleAsync(roleID, requestOptions);
                else
                    _ = discordUser.AddRoleAsync(roleID, requestOptions);
            }
            catch (Exception ex)
            {
                SEnvir.Log($"Failed to update role for DiscordID ({discordID}): {ex.Message}");
            }
        }
    }
}
