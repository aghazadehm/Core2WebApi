using System;
using Core2WebApi.Common.Security;

namespace Core2WebApi.Common.Web
{
    public interface IWebUserSession : IUserSession
    {
        string ApiVersionInUse { get; }
        Uri RequestUri { get; }
        string HttpRequestMethod { get; }
    }
}