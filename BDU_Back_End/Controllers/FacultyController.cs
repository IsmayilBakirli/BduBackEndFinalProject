using DAL.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]/[action]")]
    public class FacultyController : Controller
    {
        private readonly AppDbContext _context;

        public FacultyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Object> facultyIds=new();
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Faculties.Where(n => !n.IsDeleted).Include(n=>n.Dekans).ToListAsync();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var item in data)
            {
                if(item.Dekans.Count != 0)
                {
                    foreach (var dekan in item.Dekans)
                    {
                        facultyIds.Add(new { id = item.Id, name = item.Name, createdDate = item.CreatedDate, dekanName = dekan.Name, dekanSurname = dekan.Surname });
                    }

                }
                else
                {
                    facultyIds.Add(new { id = item.Id, name = item.Name, createdDate = item.CreatedDate });
                }

            }
            return Ok(facultyIds);
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {

            var student = await _context.Students.Where(n =>!n.IsDeleted && n.AppUserId == id).Include(n=>n.Faculty).FirstOrDefaultAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return Ok(new { id = student.Faculty.Id, name = student.Faculty.Name });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
