using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Helpers
{
    public interface IGlobalCachingProvider
    {
        void AddItem(string key, AuthenticationToken value);
        AuthenticationToken GetItem(string key);
    }
    public class GlobalCachingProvider : CachingProviderBase, IGlobalCachingProvider
    {
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly GlobalCachingProvider instance = new GlobalCachingProvider();
        }
        public static GlobalCachingProvider Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        public virtual new void AddItem(string key, AuthenticationToken value)
        {
            base.AddItem(key, value);
        }

        public virtual new AuthenticationToken GetItem(string key)
        {
            return base.GetItem(key, false);
        }
        public virtual new AuthenticationToken GetItem(string key, bool remove)
        {
            return base.GetItem(key, remove);
        }
    }
}