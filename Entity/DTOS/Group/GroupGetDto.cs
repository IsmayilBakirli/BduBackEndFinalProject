using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Group
{
    public class GroupGetDto
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? FacultyName { get; set; }

        public string? SpecialtyName { get; set; }

        public string? CreateadDate { get; set; }

    }
}
