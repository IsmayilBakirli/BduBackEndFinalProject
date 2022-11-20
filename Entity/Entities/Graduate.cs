using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Graduate:BaseEntity,IEntity
    {
        public string? Name { get; set; }
        public string? Info { get; set; }

        public int ImageId { get; set; }

        public Image? Image { get; set; }

        public int StartEducation { get; set; }
    }
}
