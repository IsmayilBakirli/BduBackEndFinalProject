﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS
{
    public class RegisterDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]

        public string? Email { get;set; }

        public string? JobYear { get; set; }

        [Required]
        public string? Password { get; set; }

        public DateTime? BirthDay { get; set; }

        public string? FinCode { get; set; }

        public string? BirthLocation { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        public string? Info { get; set; }
    }
}
