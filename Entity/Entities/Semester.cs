using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Semester:BaseEntity,IEntity
    {
        public int SemesterYear { get; set; }
    }
}
