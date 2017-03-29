using System;

namespace IoCContainer
{
    public class ObjectTypeNotRegisteredException : Exception
    {
        private const string message = "Object type {0} has not been registered";
        public ObjectTypeNotRegisteredException(string objectType) : base(string.Format(message, objectType))
        {
            
        }
    }
}