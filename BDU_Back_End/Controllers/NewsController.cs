using Business.Services;
using Entity.DTOS.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]")]
    public class NewsController : Controller
    {
        
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<NewsGetDto> data;
            try
            {
                data = await _newsService.GetAll();
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            return Ok(data);
        }


        [HttpGet,Route("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            NewsGetDto data;
            try
            {
                data = await _newsService.Get(id);
            }
            catch (Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            return Ok(data);
        }


        [HttpGet,Route("/[action]")]
        public async Task<IActionResult> GetDatas(int take)
        {
            List<NewsGetDto> data;
            try
            {
                data = await _newsService.GetTakeData(take);
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            return Ok(data);
        }
    }
}
