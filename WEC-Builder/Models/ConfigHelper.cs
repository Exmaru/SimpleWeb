using System.Configuration;

namespace WEC_Builder
{
    public class ConfigHelper
    {
        public static string GetAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            cfgCollection.Remove(key);
            cfgCollection.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void AddAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            cfgCollection.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        public static void RemoveAppConfig(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            try
            {
                cfgCollection.Remove(key);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch { }
        }

        public static void SetConnection(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var cfgCollection = config.ConnectionStrings.ConnectionStrings;

            cfgCollection.Remove(key);
            cfgCollection.Add(new ConnectionStringSettings() { Name = key, ConnectionString = value, ProviderName = "System.Data.SqlClient" });

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
        }

        public static void AddAConnection(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var cfgCollection = config.ConnectionStrings.ConnectionStrings;

            cfgCollection.Add(new ConnectionStringSettings() { Name = key, ConnectionString = value, ProviderName = "System.Data.SqlClient" });

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
        }

        public static void RemoveConnection(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var cfgCollection = config.ConnectionStrings.ConnectionStrings;

            try
            {
                cfgCollection.Remove(key);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
            }
            catch { }
        }
    }
}