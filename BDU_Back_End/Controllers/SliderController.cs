using BDU_API.Common;
using Business.Services;
using Entity.DTOS;
using Entity.DTOS.Slider;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace BDU_API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public SliderController(ISliderService sliderService,UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _sliderService = sliderService;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<SliderGetDto> data;
            try
            {
                data = await _sliderService.GetAll();
            }
            catch (EntityCouldNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound,new Response(4101,"Data Could not be found!"));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4207, ex.Message));
            }
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            SliderGetDto data;
            try
            {
                data = await _sliderService.Get(id);
            }
            catch (EntityCouldNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4101, "Data Could not be found!"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4207, ex.Message));
            }
            return Ok(data);
        }

       



        //public async Task<IActionResult> CreateSlider()
        //{


        //}

        
    }
}
