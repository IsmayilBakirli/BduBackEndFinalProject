﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Students
{
    public class StudentKollekvumsDTO
    {
        public int? First { get; set; }
        public int? Second { get; set; }
        public int? Third { get; set; }
        public int StudentId { get; set; }

        public int SubjectId { get; set; }
    }
}
