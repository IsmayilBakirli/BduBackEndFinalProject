using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class NewsImage:IEntity
    {
        public int Id { get; set; }

        public int NewsId { get; set; }

        public int ImageId { get; set; }

        public News? News { get; set; }

        public Image? Image { get; set; }
    }
}
