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
    public class NewsRepositoryDAL:EFEntityRepositoryBase<News,AppDbContext>, INewsDAL
    {
        public NewsRepositoryDAL(AppDbContext context) : base(context) { }
    }
}
