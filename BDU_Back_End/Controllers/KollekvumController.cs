using DAL.DATA;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class KollekvumController : Controller
    {
        private readonly AppDbContext _context;
        public KollekvumController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet, Route("{appuserid}/{subjectid}")]
        public async Task<IActionResult> GetForUserId(string appuserid, int subjectid)
        {
            var student = await _context.Students.Where(n => !n.IsDeleted && n.AppUserId == appuserid).FirstOrDefaultAsync();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var subjectKollekvumStudents = await _context.SubjectKollekvumStudents.Where(n => n.SubjectId == subjectid && n.StudentId == student.Id).Include(n => n.Kollekvum).FirstOrDefaultAsync();
            var kollekvum = subjectKollekvumStudents.Kollekvum;
            //#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(kollekvum);




#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }
    }
}