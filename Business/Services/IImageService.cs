using Business.Base;
using Entity.DTOS.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IImageService:IBaseService<ImageGetDto,ImageCreateDto,ImageUpdateDto>
    {
    }
}
