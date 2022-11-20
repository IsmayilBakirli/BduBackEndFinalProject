using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.User
{
    public class UserLoginDto
    {
        public string? UserName { get; set; }
        
        public string? UserEmail { get; set; }

        public string? Password { get; set; }
    }
}
