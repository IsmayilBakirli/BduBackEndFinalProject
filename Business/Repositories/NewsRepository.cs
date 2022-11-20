using AutoMapper;
using Business.Services;
using DAL.Abstracts;
using DAL.DATA;
using Entity.DTOS.News;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class NewsRepository : INewsService
    {
        private readonly INewsDAL _newsDAL;
        private readonly IMapper _mapper;
        private readonly IImageDAL _imageDAL;
        private readonly AppDbContext _context;

        public NewsRepository(INewsDAL newsDAL,IMapper mapper, IImageDAL imageDAL,AppDbContext context)
        {
            _newsDAL = newsDAL;
            _mapper = mapper;
            _imageDAL = imageDAL;
            _context= context;
        }
        public async Task<NewsGetDto> Get(int? id)
        {
            News data;
            try
            {
                data = await _newsDAL.GetAsync(expression: (n => n.Id == id && !n.IsDeleted),includes:"NewsImages.Image");
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<NewsGetDto>(data);
            return dto;
            

        }

        public async Task<List<NewsGetDto>> GetAll()
        {
            List<News> data;
            try
            {
                data = await _newsDAL.GetAllAsync(n=>!n.IsDeleted,includes:"NewsImages.Image");
            }
            catch (Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<List<NewsGetDto>>(data);
            return dto;
        }
        public async Task Create(NewsCreateDto entity)
        {
            News news = new();
            news.Title = entity.Title;
            news.Content = entity.Content;
            news.CreatedDate = DateTime.UtcNow.AddHours(4);
            List<NewsImage> newsImages = new();
            await _newsDAL.Create(news);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var item in entity.Images)
            {
                Image image = new();
                image.Name = item;
                await _imageDAL.Create(image);
                NewsImage newsImage = new();
                newsImage.ImageId = image.Id;
                newsImage.NewsId = news.Id;
                newsImages.Add(newsImage);
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            news.NewsImages = newsImages;
            await _context.SaveChangesAsync();
        }

        public Task Update(int id, NewsUpdateDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NewsGetDto>> GetTakeData(int take)
        {
            List<News> data;
            try
            {
                data = await _newsDAL.GetAllAsync(expression: (n => !n.IsDeleted), take: take,includes: "NewsImages.Image");
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<List<NewsGetDto>>(data);
            return dto;
        }
    }
}
