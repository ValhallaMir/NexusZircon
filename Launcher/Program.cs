using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Library;
using System;
using System.Reflection;
using System.Windows.Forms;
using Mir.DiscordExtension;
using Mir.DiscordExtension.SDK;

namespace Launcher
{
    static class Program
    {
        public const string PatcherFileName = @".\Patcher.exe";

        public static LMain PForm;
        public static DiscordsApp discord => DiscordsApp.GetApp();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            discord.ClientId = 1510799033327681838;
            discord.StartFailure += DiscordOnStartFailure;
            discord.Started += DiscordOnStarted;
            discord.HasException += DiscordOnHasException;
            discord.Stopped += DiscordOnStopped;
            discord.StartApp();
            discord.StartLoop();

            ConfigReader.Load(Assembly.GetAssembly(typeof(Config)));

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            discord.UpdateStage(StatusType.GameState, GameState.Patching);
            discord.UpdateStage(StatusType.PlayerName, "In the Launcher. ");
            discord.UpdateActivity();

            Application.Run(PForm = new LMain());

            ConfigReader.Save(typeof(Config).Assembly);
        }

        private static void DiscordOnActivityCallBack(object sender, EventArgs e)
        {
            Console.WriteLine($"Call back Received ({(Result)sender})");
        }

        private static void DiscordOnStopped(object sender, EventArgs e)
        {
            Console.WriteLine("Discord Stopped");
        }

        private static void DiscordOnHasException(object sender, EventArgs e)
        {
            Console.WriteLine(((Exception)sender));
        }

        private static void DiscordOnStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Discord Started");
        }

        private static void DiscordOnStartFailure(object sender, EventArgs e)
        {
            Console.WriteLine($"Discord Start failed with {(byte)sender}");
        }
    }
}
