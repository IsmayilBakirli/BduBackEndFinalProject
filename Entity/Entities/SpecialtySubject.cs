﻿using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SpecialtySubject:IEntity
    {
        public int Id { get; set; }
        public int SpecialtyId { get; set; }

        public Specialty? Specialty { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

    }
}
