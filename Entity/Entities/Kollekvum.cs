using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Kollekvum:IEntity
    {
        public int Id { get; set; }

        public int? FirstKollekvum { get; set; }

        public int? SecondKollekvum { get; set; }

        public int? ThirdKollekvum { get; set; }

    }
}
