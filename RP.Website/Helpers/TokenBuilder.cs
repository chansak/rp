using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Helpers
{
    public interface ITokenBuilder
    {
        AuthenticationToken Build(Credentials creds);
    }
    public class TokenBuilder : ITokenBuilder
    {
        public AuthenticationToken Build(Credentials creds)
        {

            var token = Guid.NewGuid().ToString();
            GlobalCachingProvider.Instance.AddItem(token, new AuthenticationToken { Token = token });
            var result = GlobalCachingProvider.Instance.GetItem(token);
            return result;
        }
    }
}