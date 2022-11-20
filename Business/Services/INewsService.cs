using Business.Base;
using Entity.DTOS.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface INewsService:IBaseService<NewsGetDto,NewsCreateDto,NewsUpdateDto>
    {
        Task<List<NewsGetDto>> GetTakeData(int take);
    }
}
