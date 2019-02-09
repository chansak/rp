using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Helpers
{
    public static class TokenValidator
    {
        public static bool IsValid(string token)
        {
            var isExistiongKey = false;
            var cacheToken = GlobalCachingProvider.Instance.GetItem(token);
            if (cacheToken != null)
            {
                isExistiongKey = true;
            }
            return isExistiongKey;
        }
    }
}