using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Teacher
{
    public class TeacherGetDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public string? UserName { get; set; }

        public string? Email { get; set; }


        public string? JobYear { get; set; }

        public string? Password { get; set; }

        public DateTime? BirthDay { get; set; }


        public string? FinCode { get; set; }

 
        public string? BirthLocation { get; set; }


        public string? ImageUrl { get; set; }

   
        public string? Info { get; set; }


        public List<string>? Groups { get; set; }


        public List<string>? Subjects { get; set; }


    }
}
