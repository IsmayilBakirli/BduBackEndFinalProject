using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Slider:BaseEntity,IEntity
    {
        public string? Title { get; set; }

        public string? Content { get; set; }


        public int ImageId { get; set; }
        public Image? Image { get; set; }


    }
}
