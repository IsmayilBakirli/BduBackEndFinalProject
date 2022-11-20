using DAL.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]/[action]")]
    public class SerbestIsController : Controller
    {
        private readonly AppDbContext _context;
        public SerbestIsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet,Route("{appuserid}/{subjectid}")]
        public async Task<IActionResult> GetForUserId(string appuserid,int subjectid)
        {
            var student = await _context.Students.Where(n => n.AppUserId == appuserid).FirstOrDefaultAsync();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var subjectSerbestIsStudents = await _context.SubjectSerbesIsStudents.Where(n => n.StudentId == student.Id && n.SubjectId == subjectid).Include(n=>n.SerbestIs).FirstOrDefaultAsync();
            var serbestIs = subjectSerbestIsStudents.SerbestIs;
            return Ok(serbestIs);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }
    }
}
