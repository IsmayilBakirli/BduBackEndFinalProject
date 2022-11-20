using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Rektor:BaseEntity,IEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public string? JobYear { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; }

        public string? ContactNumber { get; set; }

    }
}
