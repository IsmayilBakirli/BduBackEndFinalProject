using AutoMapper;
using DAL.DATA;
using Entity.DTOS.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{

    [ApiController,Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CourseController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Courses.Where(n => !n.IsDeleted).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            var dto=_mapper.Map<List<CourseGetDto>>(data);
            return Ok(dto);
        }
    }
}
