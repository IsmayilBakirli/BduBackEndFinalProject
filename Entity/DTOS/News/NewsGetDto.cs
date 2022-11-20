using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOS.News
{
    public class NewsGetDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Content { get; set; }

        public List<string>? ImageNames { get; set; }
    }
}
