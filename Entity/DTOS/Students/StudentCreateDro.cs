using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Students
{
    public class StudentCreateDro
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
        public string? Password { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public string? FinCode { get; set; }

        [Required]
        public string? BirthLocation { get; set; }

        public int GroupId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public int SpecialtyId { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? ImageUrl { get; set; }


        public int FacultyId { get; set; }

        [Required]
        public string? Division { get; set; }

        [Required]
        public string? Gender { get; set; }


    }
}
