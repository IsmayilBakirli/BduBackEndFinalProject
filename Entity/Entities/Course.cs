using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Course:BaseEntity,IEntity
    {
        public int CourseYear { get; set; }
    }
}
