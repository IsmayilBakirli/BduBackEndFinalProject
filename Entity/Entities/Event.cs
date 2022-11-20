using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Event:BaseEntity,IEntity
    {
        public string? Type { get; set; }

        public double Cost { get; set; }

        public string? Venue { get; set; }

        public string? Description { get; set; }

        public ICollection<EventImage>? ImageEvents { get; set; }

    }
}
