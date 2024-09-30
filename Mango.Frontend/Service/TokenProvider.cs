﻿using Mango.Frontend.Service.IService;
using Mango.Frontend.Utility;

namespace Mango.Frontend.Service
{
    public class TokenProvider:ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;
            bool? hastoken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out token);
            return hastoken is true ? token : null;
        }

        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }
    }
}
