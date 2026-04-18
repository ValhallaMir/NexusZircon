using Library;

namespace Launcher
{
    [ConfigPath(@".\Launcher.ini")]
    public static class Config
    {
        [ConfigSection("Patcher")]
        public static string Host { get; set; } = @"https://zirconpatch.nexusmir.com/";
        public static bool UseLogin { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int Concurrent { get; set; } = 2;
    }
}
