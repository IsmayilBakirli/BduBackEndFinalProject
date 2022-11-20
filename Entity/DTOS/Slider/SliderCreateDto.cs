using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.Slider
{
    public class SliderCreateDto
    {
        [Required(ErrorMessage ="slider must have at least one letter title")]
        public string? Title { get; set; }

        [Required]

        public string? Content { get; set; }

        [Required]

        public string? ImageUrl { get; set; }

    }
}
