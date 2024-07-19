using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public AppException(string message, int statuscode) : base(message)
        {
            StatusCode = statuscode;
        }

    }
}
