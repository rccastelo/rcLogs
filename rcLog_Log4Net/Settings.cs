using Microsoft.Extensions.Configuration;
using System.IO;

namespace rcLog_Log4Net
{
    public class Settings
    {
        private static string _configFile = "log4net.config";

        public static FileInfo GetSettingsFile()
        {
            string fileDir = Directory.GetCurrentDirectory() + @"\" + _configFile;

            return GetSettingsFile(fileDir);
        }

        public static FileInfo GetSettingsFile(string fileDirectory) 
        {
            FileInfo fi = new FileInfo(fileDirectory);

            if (fi.Exists) return fi;

            return null;
        }

        public static IConfiguration GetSettings()
        {
            IConfigurationRoot configuration;

            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(_configFile);

            configuration = builder.Build();

            return configuration;
        }

        public static string GetSettings(string sectionName, string key)
        {
            IConfigurationSection section;

            section = GetSettings().GetSection(sectionName);

            return section.GetValue<string>(key);
        }

        public static string GetSettings(string key)
        {
            return GetSettings("Settings", key);
        }

        public static string GetConnectionString()
        {
            return GetSettings("ConnectionStrings", "DefaultConnection");
        }

        public static string GetConnectionString(string key)
        {
            return GetSettings("ConnectionStrings", key);
        }
    }
}
