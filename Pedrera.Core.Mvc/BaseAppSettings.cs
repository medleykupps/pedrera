using System;
using System.Configuration;

namespace Pedrera.Core.Mvc
{
    public class BaseAppSettings : IAppSettings
    {
        public string Get(string name, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return String.Empty;
            }
            return value;
        }

        public bool Get(string name, bool defaultValue)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return false;
            }

            bool boolValue;

            return Boolean.TryParse(value, out boolValue) && boolValue;
        }

        public T Get<T>(string name, T defaultValue)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                return default(T);
            }

            // TODO: Find a way to cast the string value to a class...!?!
            // var result = (T) value;
            return default(T);
        }
    }
}
