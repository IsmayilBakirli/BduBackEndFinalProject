using Entity.Base;
using Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Teacher:BaseEntity,IEntity
    {
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public DateTime? BirthDay { get; set; }

        public string? JobYear { get; set; }

        public string? FinCode { get; set; }

        public string? BirthLocation { get; set; }
        public string? Info { get; set; }

        public ICollection<TeacherGroup>? TeacherGroups { get; set; }

        public ICollection<SubjectTeacher>? SubjectTeachers { get; set; }
    }
}
