using System.Configuration;

namespace MediaCenter
{
    public static class Settings
    {
        public static string ContentImageFolderLocation;
        public static string UserImageFolderLocation;
        public static List<string> MovieFolders;
        public static string MPCLocation;
        public static int SeriesCoverDisplayLimit;
        public static int SummaryTrimSize;
        public static long DefaultUser;

        static Settings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ContentImageFolderLocation = config.AppSettings.Settings["ContentImageFolderLocation"].Value;
            UserImageFolderLocation = config.AppSettings.Settings["UserImageFolderLocation"].Value;
            MovieFolders = config.AppSettings.Settings["MovieFolders"].Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();
            MPCLocation = config.AppSettings.Settings["MPCLocation"].Value;
            SeriesCoverDisplayLimit = int.Parse(config.AppSettings.Settings["SeriesCoverDisplayLimit"].Value);
            SummaryTrimSize = int.Parse(config.AppSettings.Settings["SummaryTrimSize"].Value);
            DefaultUser = long.Parse(config.AppSettings.Settings["DefaultUser"].Value);
        }
    }
}
