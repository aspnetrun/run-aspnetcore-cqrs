using System;

namespace AspnetRun.Core.Exceptions
{
    public class CoreException : Exception
    {
        internal CoreException()
        {
        }

        internal CoreException(string message)
            : base(message)
        {
        }

        internal CoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
