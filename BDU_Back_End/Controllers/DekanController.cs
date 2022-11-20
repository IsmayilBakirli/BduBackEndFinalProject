using DAL.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]/[action]")]
    public class DekanController : Controller
    {
        private readonly AppDbContext _context;
        public DekanController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.Dekans.Where(n => !n.IsDeleted).Include(n=>n.Faculty).ToListAsync();
            List<Object> dekans=new();
            foreach (var item in data)
            {
                dekans.Add(new {id=item.Id,name=item.Name,surname=item.Surname,fathername=item.FatherName,description=item.Description,facultyname=item?.Faculty?.Name,imageUrl=item?.ImageUrl });
            }
            return Ok(dekans);
        }
    }
}
