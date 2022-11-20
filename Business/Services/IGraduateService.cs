using Business.Base;
using Entity.DTOS.Event;
using Entity.DTOS.Graduate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IGraduateService:IBaseService<GraduateGetDto,GraduateCreateDto,GraduateUpdateDto>
    {
    }
}
