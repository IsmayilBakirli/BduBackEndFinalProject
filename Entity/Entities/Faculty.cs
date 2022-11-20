using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Faculty:BaseEntity,IEntity
    {
        public string? Name { get; set; }
        public ICollection<Dekan>? Dekans { get; set; }
    }
}
