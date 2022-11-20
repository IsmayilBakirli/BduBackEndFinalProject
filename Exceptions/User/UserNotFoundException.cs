using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.User
{
    public class UserNotFoundException:Exception
    {
        private static readonly string? _message = "User is not found";

        public UserNotFoundException() : base(_message) { }
    }
}
