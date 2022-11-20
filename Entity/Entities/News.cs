using Entity.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class News: BaseEntity, IEntity
    {
        public string? Title { get; set; }

        public string? Content { get; set; }

        public List<NewsImage>? NewsImages { get; set; }

    }
}
