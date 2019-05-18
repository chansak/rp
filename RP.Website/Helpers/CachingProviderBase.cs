using RP.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace RP.Website.Helpers
{
    public abstract class CachingProviderBase
    {
        protected MemoryCache cache = MemoryCache.Default;

        public CachingProviderBase()
        {
        }
        protected virtual void AddItem(string key, AuthenticationToken value)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            var expiry = DateTime.Now.Add(TimeSpan.FromMinutes(int.Parse(AppSettingHelper.CacheExpirationMinute)));
            value.Expiry = expiry.ToString("dd/MM/yyyy HH:mm:ss");
            policy.AbsoluteExpiration = expiry;
            cache.Add(key, value, policy);
        }

        protected virtual void RemoveItem(string key)
        {
            cache.Remove(key);
        }

        protected virtual AuthenticationToken GetItem(string key, bool remove)
        {
            AuthenticationToken res = GetItem(key);
            if (res != null && remove)
            {
                RemoveItem(key);
            }
            return res;
        }

        protected virtual AuthenticationToken GetItem(string key)
        {
            var data = cache[key] as AuthenticationToken;
            return data;
        }
    }
}