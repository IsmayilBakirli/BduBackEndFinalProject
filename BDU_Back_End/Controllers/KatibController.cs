using BDU_API.Common;
using Business.Services;
using DAL.DATA;
using Entity.DTOS.Group;
using Entity.DTOS.Katib;
using Entity.DTOS.News;
using Entity.DTOS.Slider;
using Entity.DTOS.Specialty;
using Entity.Entities;
using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

namespace BDU_API.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class KatibController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly INewsService _newsService;
        private readonly IKatibService _katibService;
        private readonly AppDbContext _context;
        public KatibController(ISliderService sliderService, INewsService newsService,IKatibService katibService,AppDbContext context)
        {
            _sliderService = sliderService;
            _newsService = newsService;
            _katibService = katibService;
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Rektor,Katib")]
        public async Task<IActionResult> Get()
        {
            List<AppUser> data;
            try
            {
                data=await _katibService.GetAll();
            }
            catch(Exception ex)
            {
                return BadRequest(new Response(4321, ex.Message));
            }
            return Ok(data);
        }
        [HttpPost]
        [Authorize(Roles = "Rektor,Katib")]
        public async Task<IActionResult> CreateSlider(SliderCreateDto sliderCreateDto)
        {
            await _sliderService.Create(sliderCreateDto);
            return Ok();
        }
        [HttpPost]
        [Authorize(Roles = "Rektor,Katib")]
        public async Task<IActionResult> CreateNews(NewsCreateDto newsCreateDto)
        {
            await _newsService.Create(newsCreateDto);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles ="Katib")]
        public async Task<IActionResult> CreateFaculty(FacultyGetDto facultyGetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            };
            Faculty faculty = new()
            {
                Name = facultyGetDto.Name,
                CreatedDate = DateTime.UtcNow.AddHours(4)
            };
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _context.Faculties.AddAsync(faculty);

            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpPost]
        [Authorize(Roles ="Katib")]
        public async Task<IActionResult> CreateSpecialty(SpecialtyCreateDTO specialtyCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            Specialty specialty = new()
            {
                Name = specialtyCreateDTO.SpecialtyName,
                FacultyId = specialtyCreateDTO.FacultyId
            };
            await _context.Specialties.AddAsync(specialty);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost,Authorize(Roles ="Katib")]
        public async Task<IActionResult> CreateGroup(GroupCreateDTO groupCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            Group group = new()
            {
                Name = groupCreateDTO.GroupName,
                SpecialtyId = groupCreateDTO.SpecialtyId
            };
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore IDE0058 // Expression value is never used