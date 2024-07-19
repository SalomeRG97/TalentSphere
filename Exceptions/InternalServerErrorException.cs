using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class InternalServerErrorException : AppException
    {
        public InternalServerErrorException(string message) : base(message, 500)
        {
        }
    }

}
