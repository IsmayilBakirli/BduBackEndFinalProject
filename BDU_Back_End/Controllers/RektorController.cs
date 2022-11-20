using BDU_API.Common;
using DAL.DATA;
using Entity.DTOS;
using Entity.DTOS.Dekan;
using Entity.DTOS.Students;
using Entity.DTOS.Teacher;
using Entity.Entities;
using Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]/[action]")]
    public class RektorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly AppDbContext _context;
        public RektorController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }


        [Authorize(Roles = "Rektor")]
        [HttpPost]
        public async Task<IActionResult> CreateKatib(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            };
            AppUser appUser = new AppUser();
            appUser.FirstName = registerDto.FirstName;
            appUser.LastName = registerDto.LastName;
            appUser.UserName = registerDto.UserName;
            appUser.Email = registerDto.Email;
            appUser.ImageUrl = registerDto.ImageUrl;
            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);
                }
                return BadRequest(ModelState.Values);
            }
            var roleResult = await _userManager.AddToRoleAsync(appUser, "Katib");

            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok();
        }

        [Authorize(Roles = "Rektor")]
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(TeacherCreateDto teacherCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            };
            AppUser appUser=new AppUser();
            appUser.FirstName = teacherCreateDto.FirstName;
            appUser.LastName = teacherCreateDto.LastName;
            appUser.UserName = teacherCreateDto.UserName;
            appUser.ImageUrl = teacherCreateDto.ImageUrl;
            appUser.Email = teacherCreateDto.Email;
            var result = await _userManager.CreateAsync(appUser, teacherCreateDto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);
                }
                return BadRequest(ModelState.Values);
            }
            var roleResult = await _userManager.AddToRoleAsync(appUser, "Muellim");

            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);
                }
                return BadRequest(ModelState.Values);
            }
            Teacher teacher = new Teacher();
            teacher.BirthDay = teacherCreateDto.BirthDay;
            teacher.BirthLocation = teacherCreateDto.BirthLocation;
            teacher.FinCode = teacherCreateDto.FinCode;
            teacher.AppUserId = appUser.Id;
            teacher.JobYear = teacherCreateDto.JobYear;
            teacher.Info = teacherCreateDto.Info;
           
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable IDE0058 // Expression value is never used
            await _context.Teachers.AddAsync(teacher);

            await _context.SaveChangesAsync();

            List<TeacherGroup> teacherGroups = new();
            foreach (var groupId in teacherCreateDto.GroupIds)
            {
                TeacherGroup teacherGroup = new();
                teacherGroup.GroupId =groupId;
                teacherGroup.TeacherId = teacher.Id;
                teacherGroups.Add(teacherGroup);
            }
            teacher.TeacherGroups = teacherGroups;


            List<SubjectTeacher> subjectTeachers = new();
            foreach (var subjectId in teacherCreateDto.SubjectIds)
            {
                SubjectTeacher subjectTeacher = new();
                subjectTeacher.SubjectId = subjectId;
                subjectTeacher.TeacherId = teacher.Id;
                subjectTeachers.Add(subjectTeacher);
            }
            teacher.SubjectTeachers = subjectTeachers;

            await _context.SaveChangesAsync();


#pragma warning restore IDE0058 // Expression value is never used
            return Ok();
        }



        [HttpPost]
        [Authorize(Roles = "Rektor")]
        public async Task<IActionResult> CreateStudent(StudentCreateDro studentCreateDro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            };
            AppUser appUser = new AppUser();
            appUser.FirstName = studentCreateDro.FirstName;
            appUser.LastName = studentCreateDro.LastName;
            appUser.UserName = studentCreateDro.UserName;
            appUser.ImageUrl = studentCreateDro.ImageUrl;
            appUser.Email = studentCreateDro.Email;
            appUser.PhoneNumber = studentCreateDro.PhoneNumber;
            var result = await _userManager.CreateAsync(appUser, studentCreateDro.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);
                }
                return BadRequest(ModelState.Values);
            }
            var roleResult = await _userManager.AddToRoleAsync(appUser, "Telebe");

            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);
                }
                return BadRequest(ModelState.Values);
            }
            Student student = new();
            student.AppUserId = appUser.Id;
            student.CourseId = studentCreateDro.CourseId;
            student.BirthDay = studentCreateDro.BirthDay;
            student.CourseId = studentCreateDro.CourseId;
            student.FacultyId = studentCreateDro.FacultyId;
            student.BirthLocation = studentCreateDro.BirthLocation;
            student.Division = studentCreateDro.Division;
            student.FinCode = studentCreateDro.FinCode;
            student.Gender = studentCreateDro.Gender;
            student.GroupId = studentCreateDro.GroupId;
            student.SpecialtyId = studentCreateDro.SpecialtyId;
            student.CourseId = 1;
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            var subjectGroups = await _context.SubjectGroups.Where(n => n.GroupId == student.GroupId).ToListAsync();

            foreach (var subjectGroup in subjectGroups)
            {
                SubjectKollekvumStudent subjectKollekvumStudent = new();
                SubjectSerbesIsStudent subjectSerbesIsStudent = new();
                Kollekvum kollekvum = new();
                SerbestIs serbestIs = new();
                await _context.Kollekvums.AddAsync(kollekvum);
                await _context.SerbestIss.AddAsync(serbestIs);
                await _context.SaveChangesAsync();

                subjectKollekvumStudent.StudentId = student.Id;
                subjectKollekvumStudent.SubjectId = subjectGroup.SubjectId;
                subjectKollekvumStudent.KollekvumId = kollekvum.Id;
               
                subjectSerbesIsStudent.StudentId = student.Id;
                subjectSerbesIsStudent.SubjectId = subjectGroup.SubjectId;
                subjectSerbesIsStudent.SerbestIsId = serbestIs.Id;
                await _context.SubjectKollekvumStudents.AddAsync(subjectKollekvumStudent);
                await _context.SubjectSerbesIsStudents.AddAsync(subjectSerbesIsStudent);
            }


            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveRektor()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var user = await _context.Rektors.Where(n => !n.IsDeleted && n.IsActive).FirstOrDefaultAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return Ok(user);
        }


        [HttpGet]

        public async Task<IActionResult> Get()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Rektors.Where(n => !n.IsDeleted).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> CreateDekan(DekanCreateDTO dekanCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var faculty = await _context.Faculties.Where(n => n.Id == dekanCreateDTO.Facultyid).Include(n=>n.Dekans).FirstOrDefaultAsync();
            foreach (var dekan in faculty.Dekans)
            {
                if (dekan != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict,new {message="faculty already have a dekan" });
                }
            }
            
            Dekan Dekan = new()
            {
                Name=dekanCreateDTO.Name,
                Description=dekanCreateDTO.Description,
                ImageUrl=dekanCreateDTO.ImageUrl,
                FacultyId=dekanCreateDTO.Facultyid,
                Surname=dekanCreateDTO.Surname,
            };
            await _context.Dekans.AddAsync(Dekan);
            await _context.SaveChangesAsync();
            return Ok();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore IDE0058 // Expression value is never used

        }
    }
}