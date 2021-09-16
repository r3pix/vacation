using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Models.Identity
{
    public class IdentityException : Exception
    {
        public IdentityException()
        {
        }

        public IdentityException(string message) : base(message)
        {
        }

        public IdentityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static IdentityException FromErrors(IEnumerable<IdentityError> errors)
        {
            IdentityException result = null;
            foreach (var error in errors.Reverse())
            {
                var innerException = new IdentityException(error.Description, result);
                result = innerException;
            }

            return result;
        }
    }
}
