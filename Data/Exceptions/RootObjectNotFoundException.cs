using System;

namespace Core2WebApi.Data.Exceptions
{
    public class RootObjectNotFoundException : Exception
    {
        public RootObjectNotFoundException(string message) : base(message)
        {
        }
    }
}