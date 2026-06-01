namespace Mir.DiscordExtension
{
    public class DiscordSettings
    {
        public bool DisplayCharacterName { get; set; } = true;
        public string DetailsFormatting { get; set; } = "{0}{1}{2}";
        public bool EnableDiscordActivity { get; set; } = true;
        public string LargeImage { get; set; } = "nexus_logo_v5_square";
        public string SmallImage { get; set; } = "nexus_logo_v5_square";
        public bool ShowGroup { get; set; } = true;

        public DiscordSettings()
        {

        }
    }
}
