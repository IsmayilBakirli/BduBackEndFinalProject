using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ProRektor:BaseEntity,IEntity
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? FatherName { get; set; }
        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public string? Email { get; set; }

        public string? Telephone { get; set; }

    }
}
