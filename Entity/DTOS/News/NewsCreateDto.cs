using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.News
{
    public class NewsCreateDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }


        [Required,MinLength(1)]
        public List<string>? Images { get; set; }
    }
}
