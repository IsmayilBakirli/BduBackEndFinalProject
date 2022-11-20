using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Event
{
    public class EventGetDto
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        public double Cost { get; set; }

        public string? Venue { get; set; }

        public string? Description { get; set; }

        public List<string>? ImageNames { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}