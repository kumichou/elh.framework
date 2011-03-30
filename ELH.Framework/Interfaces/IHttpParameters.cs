using System;

namespace ELH.Framework.Interfaces
{
    public interface IHttpParameters
    {
        T GetValue<T>(string key);
        T GetValue<T>(string key, T nullValue);
    }
}
