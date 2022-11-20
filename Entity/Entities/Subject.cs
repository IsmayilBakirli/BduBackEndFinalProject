using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{ 
    public class Subject:BaseEntity,IEntity
    {
        public string? Name { get; set; }
        public ICollection<SubjectCourse>? SubjectCourses { get; set; }

        public ICollection<SubjectSemester>? SubjectSemesters { get; set; }
    }
}
