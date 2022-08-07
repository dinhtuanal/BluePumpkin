using System;

namespace SharedObjects.Commons
{
    public class CustomException : Exception
    {
        public int statusCode;
        public CustomException()
        {

        }

        public CustomException(string message, int statusCode) : base(message)
        {
            this.statusCode = statusCode;
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}