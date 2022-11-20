using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Teacher
{
    public class TeacherCreateDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]

        public string? Email { get; set; }

        [Required]
        public string? JobYear { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public DateTime? BirthDay { get; set; }

        [Required]
        public string? FinCode { get; set; }

        [Required]
        public string? BirthLocation { get; set; }


        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        public string? Info { get; set; }

        [Required]
        public List<int>? GroupIds { get; set; }

        [Required]
        public List<int>? SubjectIds { get; set; }

    }
}
