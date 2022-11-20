using Business.Services;
using DAL.Abstracts;
using Entity.DTOS.Image;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ImageRepository : IImageService
    {
        private readonly IImageDAL _imageDAL;
        public ImageRepository(IImageDAL imageDAL)
        {
            _imageDAL = imageDAL;
        }
        public Task<ImageGetDto> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageGetDto>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task Create(ImageCreateDto entity)
        {
            Image image = new Image();
            image.Name = entity.Name;
            await _imageDAL.Create(image);
        }

        public Task Update(int id, ImageUpdateDto entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }


    }
}
