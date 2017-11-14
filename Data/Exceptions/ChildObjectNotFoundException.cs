using System;

namespace Core2WebApi.Data.Exceptions
{
    public class ChildObjectNotFoundException : Exception
    {
        public ChildObjectNotFoundException(string message) : base(message)
        {
        }
    }
}