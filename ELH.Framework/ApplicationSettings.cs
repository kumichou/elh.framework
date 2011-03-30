using System;
using System.Configuration;
using ELH.Framework.Base;
using ELH.Framework.Interfaces;

namespace ELH.Framework
{
    public class ApplicationSettings : ValueConvertBase, IApplicationSettings
    {
        /// <summary>
        /// Returns the typed value of an Application Configuration's appSetting <see cref="System.Collections.Specialized.NameValueCollection" /> key.
        /// </summary>
        /// <typeparam name="T">The <see cref="System.Type" /> to return.</typeparam>
        /// <param name="key">The key used to retrieve a value.</param>
        /// <returns>A value of the given <see cref="System.Type" />.</returns>
        public T GetAppSettingValue<T>(string key)
        {
            return GetAppSettingValue<T>(key, default(T));
        }

        /// <summary>
        /// Returns the typed value of an Application Configuration's appSetting <see cref="System.Collections.Specialized.NameValueCollection" /> key.
        /// </summary>
        /// <typeparam name="T">The <see cref="System.Type" /> to return.</typeparam>
        /// <param name="key">The key used to retrieve a value.</param>
        /// <param name="nullValue">A value to return in the event a proper value isn't found in the Querystring or Form <see cref="System.Collections.Specialized.NameValueCollection" />.</param>
        /// <returns>A value of the given <see cref="System.Type" />.</returns>
        public T GetAppSettingValue<T>(string key, T nullValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            string keyValue = ConfigurationManager.AppSettings[key];
            T result = GetValue<T>(nullValue, keyValue);
            return result;
        }

        /// <summary>
        /// Returns the typed value of an Application Configuration's appSetting <see cref="System.Collections.Specialized.NameValueCollection" /> key.
        /// </summary>
        /// <typeparam name="T">The <see cref="System.Type" /> to return.</typeparam>
        /// <param name="key">The key used to retrieve a value.</param>
        /// <param name="nullValue">A value to return in the event a proper value isn't found in the Querystring or Form <see cref="System.Collections.Specialized.NameValueCollection" />.</param>
        /// <param name="configFilePath">A fully qualified file system path that points to a .NET Application Configuration file containing appSettings.</param>
        /// <returns>A value of the given <see cref="System.Type" />.</returns>
        public T GetAppSettingValueFromConfigFile<T>(string key, T nullValue, string configFilePath)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (string.IsNullOrEmpty(configFilePath))
            {
                throw new ArgumentException("configFilePath");
            }

            var config = ConfigurationManager.OpenExeConfiguration(configFilePath);
            string keyValue = config.AppSettings.Settings[key].Value;
            T result = GetValue<T>(nullValue, keyValue);
            return result;
        }
    }
}
