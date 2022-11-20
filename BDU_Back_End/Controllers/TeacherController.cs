using BDU_API.Common;
using DAL.DATA;
using Entity.DTOS.Students;
using Entity.DTOS.Teacher;
using Entity.Entities;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public TeacherController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var data = await _context.Teachers.Where(n => !n.IsDeleted).Include(n => n.TeacherGroups).ThenInclude(n => n.Group).Include(n => n.AppUser).Include(n => n.SubjectTeachers).ThenInclude(n => n.Subject).ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
#pragma warning restore CS8604 // Possible null reference argument.
            List<TeacherGetDto> teacherGetDtos = new();
            foreach (var item in data)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                TeacherGetDto teacherGetDto = new();
                List<string> groups = new();
                List<string> subjects = new();
                teacherGetDto.BirthDay = item.BirthDay;
                teacherGetDto.FirstName = item.AppUser.FirstName;
                teacherGetDto.LastName = item.AppUser.LastName;
                teacherGetDto.UserName = item.AppUser.UserName;
                teacherGetDto.BirthLocation = item.BirthLocation;
                teacherGetDto.Email = item.AppUser.Email;
                teacherGetDto.FinCode = item.FinCode;
                teacherGetDto.ImageUrl = item.AppUser.ImageUrl;
                teacherGetDto.Info = item.Info;
                teacherGetDto.Id = item.Id;
                teacherGetDto.JobYear = item.JobYear;
                foreach (var group in item.TeacherGroups)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    groups.Add(group.Group.Name);
                }
                foreach (var subject in item.SubjectTeachers)
                {
                    subjects.Add(subject.Subject.Name);
                }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                teacherGetDto.Groups = groups;
                teacherGetDto.Subjects = subjects;
                teacherGetDtos.Add(teacherGetDto);
            }
            return Ok(teacherGetDtos);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var data = await _context.Teachers.Where(n => !n.IsDeleted && n.Id == id).Include(n => n.TeacherGroups).ThenInclude(n => n.Group).Include(n => n.AppUser).Include(n => n.SubjectTeachers).ThenInclude(n => n.Subject).FirstOrDefaultAsync();
            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4321, "data is null"));
            }
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            TeacherGetDto teacherGetDto = new();
            List<string> groups = new();
            List<string> subjects = new();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            teacherGetDto.BirthDay = data.BirthDay;

            teacherGetDto.FirstName = data.AppUser.FirstName;
            teacherGetDto.LastName = data.AppUser.LastName;
            teacherGetDto.UserName = data.AppUser.UserName;
            teacherGetDto.BirthLocation = data.BirthLocation;
            teacherGetDto.Email = data.AppUser.Email;
            teacherGetDto.FinCode = data.FinCode;
            teacherGetDto.ImageUrl = data.AppUser.ImageUrl;
            teacherGetDto.Info = data.Info;
            teacherGetDto.Id = data.Id;
            teacherGetDto.JobYear = data.JobYear;
            foreach (var group in data.TeacherGroups)
            {
                groups.Add(group.Group.Name);
            }
            foreach (var subject in data.SubjectTeachers)
            {
                subjects.Add(subject.Subject.Name);
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
            teacherGetDto.Groups = groups;
            teacherGetDto.Subjects = subjects;
            return Ok(teacherGetDto);
        }

        [HttpGet, Route("{subjectid}/{groupid}")]
        public async Task<IActionResult> GetTeachers(int subjectid, int groupid)
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var datas = await _context.Teachers.Where(n => !n.IsDeleted).Include(n => n.TeacherGroups).Include(n => n.SubjectTeachers).Include(n => n.AppUser).ToListAsync();
            var subjectTeachers = await _context.SubjectTeachers.Include(n => n.Teacher).ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            List<Teacher> teachers = new();
            foreach (var subjectTeacher in subjectTeachers)
            {
                if (subjectTeacher.SubjectId == subjectid)
                {
                    teachers.Add(subjectTeacher.Teacher);
                }
            }
            List<Teacher> newTeachers = new();
            foreach (var teacher in teachers)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                foreach (var item in teacher.TeacherGroups)
                {
                    if (item.GroupId == groupid)
                    {
                        newTeachers.Add(teacher);
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(newTeachers);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetForAppUserId(string id)
        {
            var user = await _context.Teachers.Where(n => n.AppUserId == id).Include(n => n.AppUser).FirstOrDefaultAsync();
            return Ok(user);

        }



        [HttpPost]

        public async Task<IActionResult> AddKollekvum(StudentKollekvumsDTO kollekvums)
        {
            int? firstKollekvum = kollekvums.First;
            int? secondKollekvum = kollekvums.Second;
            int? thirdKollekvum = kollekvums.Third;
            int studentid = kollekvums.StudentId;
            int subjectId = kollekvums.SubjectId;
            var studentKollekvumSubject = await _context.SubjectKollekvumStudents.Where(n => n.StudentId == studentid && n.SubjectId == subjectId).Include(n => n.Kollekvum).FirstOrDefaultAsync();
            if (firstKollekvum > 10 || firstKollekvum < 0 || secondKollekvum > 10 || secondKollekvum < 0 || thirdKollekvum > 10 || thirdKollekvum < 0)
            {
                return BadRequest(new Response(4323, "please enter between 1-10 numbers"));
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (studentKollekvumSubject.Kollekvum.FirstKollekvum == firstKollekvum && studentKollekvumSubject.Kollekvum.SecondKollekvum == secondKollekvum && studentKollekvumSubject.Kollekvum.ThirdKollekvum == thirdKollekvum)
            {
                return Ok(new { message = "not change" });
            }
            else
            {
                studentKollekvumSubject.Kollekvum.FirstKollekvum = firstKollekvum;
                studentKollekvumSubject.Kollekvum.SecondKollekvum = secondKollekvum;
                studentKollekvumSubject.Kollekvum.ThirdKollekvum = thirdKollekvum;
#pragma warning disable IDE0058 // Expression value is never used
                await _context.SaveChangesAsync();
            }


            return Ok(kollekvums);
        }


        [HttpPost]
        public async Task<IActionResult> AddSerbestIs(StudentSerbestIssDTO studentSerbestIssDTO)
        {
            int? one = studentSerbestIssDTO.One;
            int? two = studentSerbestIssDTO.Two;
            int? three = studentSerbestIssDTO.Three;
            int? four = studentSerbestIssDTO.Four;
            int? five = studentSerbestIssDTO.Five;
            int? six = studentSerbestIssDTO.Six;
            int? seven = studentSerbestIssDTO.Seven;
            int? eight = studentSerbestIssDTO.Eight;
            int? nine = studentSerbestIssDTO.Nine;
            int? ten = studentSerbestIssDTO.Ten;
            int studentid = studentSerbestIssDTO.StudentId;
            int subjectid = studentSerbestIssDTO.SubjectId;

            var studentSerbestIsSubject = await _context.SubjectSerbesIsStudents.Where(n => n.StudentId == studentid && n.SubjectId == subjectid).Include(n => n.SerbestIs).FirstOrDefaultAsync();

            if(studentSerbestIsSubject.SerbestIs.FirstGrade==one && studentSerbestIsSubject.SerbestIs.SecondGrade==two && studentSerbestIsSubject.SerbestIs.ThirdGrade==three && studentSerbestIsSubject.SerbestIs.FourthGrade==four && studentSerbestIsSubject.SerbestIs.FiveGrade==five &&
                studentSerbestIsSubject.SerbestIs.SixGrade==six && studentSerbestIsSubject.SerbestIs.SevenGrade==seven && studentSerbestIsSubject.SerbestIs.EightGrade==eight && studentSerbestIsSubject.SerbestIs.NineGrade==nine && studentSerbestIsSubject.SerbestIs.TenGrade == ten)
            {
                return Ok(new { message = "not change" });
            }
            if ((one == 0 || one == 1 || one==null) && (two==0 || two==1 || two ==null) && (three == 0 || three == 1 || three == null ) && (four == 0 || four == 1 || four == null ) && (five == 0 || five == 1 || five == null ) && (six == 0 || six == 1 || six == null ) && (seven == 0 || seven == 1 || seven == null )
                && (eight == 0 || eight == 1 || eight == null ) && (nine == 0 || nine == 1 || nine == null ) && (ten==0 || ten==1 || ten==null))
            {
                studentSerbestIsSubject.SerbestIs.FirstGrade = one;
                studentSerbestIsSubject.SerbestIs.SecondGrade = two;
                studentSerbestIsSubject.SerbestIs.ThirdGrade = three;
                studentSerbestIsSubject.SerbestIs.FourthGrade = four;
                studentSerbestIsSubject.SerbestIs.FiveGrade = five;
                studentSerbestIsSubject.SerbestIs.SixGrade = six;
                studentSerbestIsSubject.SerbestIs.SevenGrade = seven;
                studentSerbestIsSubject.SerbestIs.EightGrade = eight;
                studentSerbestIsSubject.SerbestIs.NineGrade = nine;
                studentSerbestIsSubject.SerbestIs.TenGrade = ten;

            }
            
            else
            {
                return BadRequest(new Response(4323, "please enter 0 or 1"));
            }
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

