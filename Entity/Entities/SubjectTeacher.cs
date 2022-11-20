using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SubjectTeacher:IEntity
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public Subject? Subject { get; set; }

        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
