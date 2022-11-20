using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Katib
{
    public class FacultyGetDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
