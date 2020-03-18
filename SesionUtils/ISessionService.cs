using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Session_Manager.SesionUtils
{
    /// <summary>
    /// Session管理服务
    /// </summary>
    public interface ISessionService
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);
        void Remove(params string[] keys);
    }
}
