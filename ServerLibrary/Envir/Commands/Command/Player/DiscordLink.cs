using DiscordLibrary;
using Library;
using Server.Models;
using System.Security.Principal;

namespace Server.Envir.Commands.Command.Player
{
    class DiscordLink : AbstractCommand<IPlayerCommand>
    {
        public override string VALUE => "LINK";

        public override void Action(PlayerObject player)
        {
            if (player.DiscordLinked)
            {
                player.Connection.ReceiveChat($"Your account is already linked to Discord! Use @Unlink to unlink your account.", MessageType.System);
                
                return;
            }
            player.Character.Account.DiscordLinkCode = (ushort)SEnvir.Random.Next(10000, 65000);
            player.Connection.ReceiveChat($"Your LinkCode is {player.Character.Account.DiscordLinkCode}. Use the '/NexusMir Link' command on Discord to complete the setup.", MessageType.System);
            player.Connection.ReceiveChat($"Use @Unlink to unlink your account.", MessageType.System);
            SEnvir.Log($"{player.Name} has created LinkCode {player.Character.Account.DiscordLinkCode} for {player.Character.Account.EMailAddress}");
        }
    }

    class DiscordUnLink : AbstractCommand<IPlayerCommand>
    {
        public override string VALUE => "UNLINK";

        public override void Action(PlayerObject player)
        {
            if (player.DiscordLinked)
            {
                DiscordApp.UpdateRole(player.Character.Account.DiscordID, true, 1310105163574280312);
                player.Character.Account.DiscordID = 0;
                player.Connection.ReceiveChat($"Your account is no longer linked to Discord.", MessageType.System);
                return;
            }
            else
            {
                player.Connection.ReceiveChat($"Your account is not linked to Discord.", MessageType.System);
            }
        }
    }
}
