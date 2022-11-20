using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Specialty
{
    public class SpecialtyGetDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? FacultyName { get; set; }

        public string? CreatedDate { get; set; }
    }
}
