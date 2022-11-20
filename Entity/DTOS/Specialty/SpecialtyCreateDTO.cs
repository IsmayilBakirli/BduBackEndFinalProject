using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Specialty
{
    public class SpecialtyCreateDTO
    {
        [Required]
        public string? SpecialtyName { get; set; }
        [Required]
        public int FacultyId { get; set; }
    }
}
