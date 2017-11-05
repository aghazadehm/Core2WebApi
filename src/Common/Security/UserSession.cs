using System;
using System.Security.Claims;
using Core2WebApi.Common.Web;
using Microsoft.AspNetCore.Http;

namespace Core2WebApi.Common.Security
{
    public class UserSession : IWebUserSession
    {
        private readonly HttpContext _httpContext;
        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        public string ApiVersionInUse
        {
            get
            {
                const int versionIndex = 2;
                var pathSegments = _httpContext.Request.Path.Value.Split('/');
                if (pathSegments.Length < versionIndex)
                {
                    return string.Empty;
                }
                var apiVersionInUse = pathSegments[versionIndex];
                return apiVersionInUse;
            }
        }

        public Uri RequestUri
        {
            get
            {
                var request = _httpContext.Request;
                UriBuilder uriBuilder = new UriBuilder(
                request.Scheme,
                request.Host.Host,
                request.Host.Port.Value,
                request.Path.Value);
                return uriBuilder.Uri;
            }
        }

        public string HttpRequestMethod => _httpContext.Request.Method;

        public string Firstname => _httpContext.User.FindFirst((ClaimTypes.GivenName)).Value;

        public string Lastname => _httpContext.User.FindFirst((ClaimTypes.Surname)).Value;

        public string Username => _httpContext.User.FindFirst((ClaimTypes.Name)).Value;

        public bool IsInRole(string roleName) => _httpContext.User.IsInRole(roleName);
    }
}