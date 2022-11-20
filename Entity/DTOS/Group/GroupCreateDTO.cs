using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Group
{
    public class GroupCreateDTO
    {
        [Required]
        public int FacultyId { get; set; }

        [Required]
        public int SpecialtyId { get; set; }

        [Required]
        public string? GroupName { get; set; }
    }
}
