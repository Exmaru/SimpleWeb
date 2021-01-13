using System;
using System.Security.Authentication;

namespace WebEngine
{
    public class AuthException : AuthenticationException
    {
        public AuthException() : base()
        {
        }

        public AuthException(string message) : base(message)
        {
        }

        public AuthException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}