using AutoMapper;
using Business.Services;
using DAL.Abstracts;
using Entity.DTOS.Slider;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class SliderRepository : ISliderService
    {
        private readonly ISliderDAL _sliderDal;
        private readonly IImageDAL _imageDAL;
        private readonly IMapper _mapper;
        public SliderRepository(ISliderDAL sliderDal,IMapper mapper, IImageDAL imageDAL)
        {
            _sliderDal = sliderDal;
            _mapper = mapper;
            _imageDAL = imageDAL;
        }

        public async Task<SliderGetDto> Get(int? id)
        {
            Slider data;
            try
            {
                data = await _sliderDal.GetAsync((n => n.Id == id), includes: "Image");
            }
            catch (Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<SliderGetDto>(data);
            return dto;
        }

        public async Task<List<SliderGetDto>> GetAll()
        {
            List<Slider> data;
            try
            {
                data = await _sliderDal.GetAllAsync((n => !n.IsDeleted), includes: "Image");
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            List<SliderGetDto> dtos = _mapper.Map<List<SliderGetDto>>(data);
            return dtos;
        }
        public async Task Create(SliderCreateDto entity)
        {
            Image image = new Image();
            image.Name = entity.ImageUrl;
            await _imageDAL.Create(image);
            Slider slider = new Slider();
            slider.ImageId = image.Id;
            slider.Title = entity.Title;
            slider.Content = entity.Content;
            slider.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _sliderDal.Create(slider);
        }
        public Task Update(int id, SliderUpdateDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

    }
}