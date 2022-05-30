using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Domain.Exceptions
{
    public class DbScopeException : Exception
    {
        public DbScopeException(string message) : base(message) { }
    }
}
