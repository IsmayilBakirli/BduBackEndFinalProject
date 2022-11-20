using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SubjectCourse
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public Subject? Subject { get; set; }

        public int CourseId { get; set; }

        public Course? Course { get; set; }

    }
}
