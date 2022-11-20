using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Graduate
{
    public class GraduateGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Info { get; set; }

        public string? ImageName { get; set; }

        public int StartEducation { get; set; }
    }
}
