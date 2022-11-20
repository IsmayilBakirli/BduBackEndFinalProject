using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Dekan
{
    public class DekanCreateDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int Facultyid { get; set; }
    }
}
