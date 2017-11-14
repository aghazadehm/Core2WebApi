using System;

namespace Core2WebApi.Common
{
    public class ApplicationInfoAdapter : IApplicationInfo
    {
        public string ApplicationName => AppDomain.CurrentDomain.FriendlyName;
    }
}