using Core.EFRepository;
using DAL.Abstracts;
using DAL.DATA;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ImageRepositoryDAL:EFEntityRepositoryBase<Image,AppDbContext>,IImageDAL
    {
        public ImageRepositoryDAL(AppDbContext context) : base(context) { }
    }
}
