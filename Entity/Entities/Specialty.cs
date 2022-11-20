﻿using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Specialty:BaseEntity,IEntity
    {
        public string? Name { get; set; }

        public int FacultyId { get; set; }

        public Faculty? Faculty { get; set; }

        
    }
}
