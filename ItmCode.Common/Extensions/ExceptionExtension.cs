
using System;
using System.Collections.Generic;

namespace ItmCode.Common.Extensions
{
    public static class ExceptionExtension
    {
        public static IEnumerable<string> ExceptionMessages(this Exception exception)
        {
            yield return exception.Message;

            var innerException = exception.InnerException;
            while (innerException != null)
            {
                yield return innerException.Message;
                innerException = innerException.InnerException;
            }
        }

        public static IEnumerable<string> InnerExceptionMessages(this Exception exception)
        {
            var innerException = exception.InnerException;
            while (innerException != null)
            {
                yield return innerException.Message;
                innerException = innerException.InnerException;
            }
        }
    }
}