using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.EntityExceptions
{
    public class EntityCouldNotFoundException:Exception
    {
        private static readonly string? _message="Entity could not found!";
        public EntityCouldNotFoundException():base(_message) { }
    }
}
