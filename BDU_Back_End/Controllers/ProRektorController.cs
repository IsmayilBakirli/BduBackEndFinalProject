using DAL.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProRektorController : Controller
    {
        private readonly AppDbContext _context;
        public ProRektorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.ProRektors.Where(n => !n.IsDeleted).ToListAsync();
            return Ok(data);

        }
    }
}