using Microsoft.Extensions.Configuration;
using System.IO;

namespace rcLogs_Serilog
{
    public class Settings
    {
        private static string _configFile = "serilog.config.json";

        public static FileInfo GetFileSettings()
        {
            string fileDir = Directory.GetCurrentDirectory() + @"\" + _configFile;

            return GetFileSettings(fileDir);
        }

        public static FileInfo GetFileSettings(string fileDirectory) 
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

        public static string GetValue(string key)
        {
            return GetSettings().GetValue<string>(key);
        }

        public static string GetConnectionStringDefault()
        {
            return GetSettings("ConnectionStrings", "DefaultConnection");
        }

        public static string GetConnectionString(string key)
        {
            return GetSettings("ConnectionStrings", key);
        }
    }
}
