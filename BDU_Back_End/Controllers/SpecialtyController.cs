using AutoMapper;
using DAL.DATA;
using Entity.DTOS.Specialty;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]/[action]")]
    public class SpecialtyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SpecialtyController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper= mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Specialties.Where(n => !n.IsDeleted).Include(n=>n.Faculty).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            var dto = _mapper.Map<List<SpecialtyGetDto>>(data);
            return Ok(dto);
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetForFacultyId(int id)
        {
            List<Object> datas = new();
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Specialties.Where(n => !n.IsDeleted && n.FacultyId == id).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            foreach (var item in data)
            {
                datas.Add(new { id = item.Id, name = item.Name });
            }
            return Ok(datas);
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetForUserId(string id)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var user = await _context.Students.Where(n => !n.IsDeleted && n.AppUserId == id).Include(n => n.Specialty).FirstOrDefaultAsync();
#pragma warning restore CS8604 // Possible null reference argument.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return Ok(new {id=user.SpecialtyId,name=user.Specialty.Name });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
