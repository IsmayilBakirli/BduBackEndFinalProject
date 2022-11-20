using BDU_API.Common;
using DAL.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController,Route("/api/[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Students.Where(n => !n.IsDeleted).Include(n=>n.AppUser).Include(n=>n.Faculty).Include(n=>n.Group).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            List<Object> students=new();
            foreach (var item in data)
            {
                students.Add(new { id = item.Id, imageUrl = item?.AppUser?.ImageUrl, name = item?.AppUser?.FirstName, surname = item?.AppUser?.LastName, facultyname = item?.Faculty?.Name,groupId=item?.Group?.Name }) ;
            }
            return Ok(students);
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetAppUserId(string id)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Students.Where(n => !n.IsDeleted && n.AppUserId == id).FirstOrDefaultAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            return Ok(data);
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetForGroupId(int id)
        {
  
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var data = await _context.Students.Where(n => !n.IsDeleted && n.Group.Id == id).Include(n => n.AppUser).ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            List<Object> students = new();
            foreach (var item in data)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                students.Add(new {item.Id,item.AppUser.FirstName,item.AppUser.LastName });

            }
            return Ok(students);
        }


        [HttpGet, Route("{id}/{subjectId}")]
        public async Task<IActionResult> GetStudentDetail(int id,int subjectId)
        {
            var student = await _context.Students.Where(n => n.Id == id).Include(n => n.AppUser).FirstOrDefaultAsync();
            var subjectStudentKollekvum = await _context.SubjectKollekvumStudents.Where(n => n.StudentId == id && n.SubjectId ==subjectId).Include(n=>n.Kollekvum).FirstOrDefaultAsync();
            var subjectStudentSerbestIs = await _context.SubjectSerbesIsStudents.Where(n => n.StudentId == id && n.SubjectId == subjectId).Include(n => n.SerbestIs).FirstOrDefaultAsync();
            
            var studentDetail = new
            {
                id = student.Id,
                name = student.AppUser.FirstName,
                lastname = student.AppUser.LastName,
                firstKollekvum = subjectStudentKollekvum.Kollekvum!=null ? subjectStudentKollekvum.Kollekvum.FirstKollekvum : null,
                secondKollekvum = subjectStudentKollekvum.Kollekvum!=null ? subjectStudentKollekvum.Kollekvum.SecondKollekvum :null,
                thirdKollekvum = subjectStudentKollekvum.Kollekvum != null ? subjectStudentKollekvum.Kollekvum.ThirdKollekvum : null,
                firstSerbestIs = subjectStudentSerbestIs.SerbestIs !=null ? subjectStudentSerbestIs.SerbestIs.FirstGrade : null,
                secondSerbestIs = subjectStudentSerbestIs.SerbestIs !=null ? subjectStudentSerbestIs.SerbestIs.SecondGrade :null,
                thirdSerbestIs = subjectStudentSerbestIs.SerbestIs!=null ? subjectStudentSerbestIs.SerbestIs.ThirdGrade : null,
                fourthSerbestIs = subjectStudentSerbestIs.SerbestIs!= null ? subjectStudentSerbestIs.SerbestIs.FourthGrade : null,
                fiveSerbestIs = subjectStudentSerbestIs.SerbestIs!=null ? subjectStudentSerbestIs.SerbestIs.FiveGrade :null,
                sixSerbestIs= subjectStudentSerbestIs.SerbestIs!=null ? subjectStudentSerbestIs.SerbestIs.SixGrade :null,
                sevenSerbestIs = subjectStudentSerbestIs.SerbestIs!=null ? subjectStudentSerbestIs.SerbestIs.SevenGrade :null,
                eightSerbestIs = subjectStudentSerbestIs.SerbestIs!=null ? subjectStudentSerbestIs.SerbestIs.EightGrade : null,
                nineSerbestIs = subjectStudentSerbestIs.SerbestIs !=null ?subjectStudentSerbestIs.SerbestIs.NineGrade : null,
                tenSerbestIs = subjectStudentSerbestIs.SerbestIs !=null ?subjectStudentSerbestIs.SerbestIs.TenGrade :null
            };
            return Ok(studentDetail);
        }
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.