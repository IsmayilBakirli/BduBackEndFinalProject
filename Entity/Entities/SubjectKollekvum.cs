using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SubjectKollekvumStudent:IEntity
    {
        public int Id { get; set; }

        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        
        public int? KollekvumId { get; set; }

        public Kollekvum? Kollekvum { get; set; }

        public int StudentId { get; set; }

        public Student? Student { get; set; }

    }
}
