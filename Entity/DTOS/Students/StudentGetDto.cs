using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Students
{
    public class StudentGetDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime? BirthDay { get; set; }

        public string? FinCode { get; set; }

        public string? BirthLocation { get; set; }

        public string? ImageUrl { get; set; }

        public string? Group { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Specialty { get; set; }
    }
}
