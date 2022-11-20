using Business.Services;
using Entity.DTOS.Graduate;
using Microsoft.AspNetCore.Mvc;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]")]
    public class GraduateController : Controller
    {
        private readonly IGraduateService _graduateService;
        public GraduateController(IGraduateService graduateService)
        {
            _graduateService = graduateService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<GraduateGetDto> data;
            try
            {
                data = await _graduateService.GetAll();
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
