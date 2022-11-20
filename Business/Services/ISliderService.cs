using Business.Base;
using Entity.DTOS.Slider;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public interface ISliderService:IBaseService<SliderGetDto,SliderCreateDto,SliderUpdateDto>
    {
    }
}
