using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Session_Manager.SesionUtils
{
    public class SessionService : ISessionService
    {
        private readonly ISession _SESSION;
        public SessionService(IHttpContextAccessor httpContextRepository)
        {
            _SESSION = httpContextRepository.HttpContext.Session;
            if (_SESSION == null)
            {
                throw new ArgumentNullException("Sesion cannot be null.");
            }
        }
        public T Get<T>(string key)
        {
            string value = _SESSION.GetString(key);
            if (string.IsNullOrWhiteSpace(value))
                return default(T);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }

        public void Remove(params string[] keys)
        {
            if (keys == null)
                return;
            else
                foreach (string key in keys)
                {
                    _SESSION.Remove(key);
                }
        }

        public void Set<T>(string key, T value)
        {
            if (value == null)
                Remove(key);
            else
                _SESSION.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }
    }
}
