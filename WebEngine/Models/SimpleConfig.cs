using System;
using System.Configuration;

namespace WebEngine
{
    public class SimpleConfig
    {

        private static readonly Lazy<SimpleConfig> lazy = new Lazy<SimpleConfig>(() => new SimpleConfig());
        public static SimpleConfig Global { get { return lazy.Value; } }

        public SimpleConfig()
        {

        }

        public string GetConnection(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] != null)
            {
                return ConfigurationManager.ConnectionStrings[key].ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public string GetString(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key];
            }
            else
            {
                return String.Empty;
            }
        }

        public bool GetBoolean(string key)
        {
            return GetString(key).Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        public int GetInt(string key)
        {
            int result = 0;
            if (int.TryParse(GetString(key), out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        public long GetLong(string key)
        {
            long result = 0;
            if (long.TryParse(GetString(key), out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}