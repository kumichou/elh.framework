using System;

namespace ELH.Framework.Interfaces
{
    public interface IApplicationSettings
    {
        T GetAppSettingValue<T>(string key);
        T GetAppSettingValue<T>(string key, T nullValue);
        T GetAppSettingValueFromConfigFile<T>(string key, T nullValue, string configFilePath);
    }
}
