using AutoMapper;
using DAL.DATA;
using Entity.DTOS.Group;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]/[action]")]
    public class GroupController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GroupController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var data = await _context.Groups.Where(n => !n.IsDeleted).Include(n=>n.Specialty).ThenInclude(n=>n.Faculty).ToListAsync();

            var dto=_mapper.Map<List<GroupGetDto>>(data);
            return Ok(dto);
        }

        //[HttpGet]
        //[Route("/[action]")]
        //public async Task<IActionResult> GetForSpecialtyName()
        //{

        //}

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetForSpecialtyId(int id)
        {

            var groups = await _context.Groups.Where(n => n.SpecialtyId == id).ToListAsync();


            List<Object> groupIds = new();
            foreach (var item in groups)
            {
                groupIds.Add(new { id = item.Id, groupName = item.Name });
            }
            return Ok(groupIds);
        }

        [HttpGet,Route("{studentId}")]
        public async Task<IActionResult> GetForStudentId(string studentId)
        {

            var data = await _context.Students.Where(n => !n.IsDeleted && n.AppUserId == studentId).Include(n => n.Group).FirstOrDefaultAsync();

            return Ok(new {id=data.GroupId,name=data.Group.Name});


        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetForTeacherId(string id)
        {
            var user = await _context.Users.Where(n => n.Id == id).FirstOrDefaultAsync();

            var teacher = await _context.Teachers.Where(n => n.AppUserId == user.Id).FirstOrDefaultAsync();
            var teacherGroups = await _context.TeacherGroups.Where(n => n.TeacherId == teacher.Id).Include(n=>n.Group).ToListAsync();
            var groupSubjects = await _context.SubjectGroups.Include(n=>n.Subject).ToListAsync();
            List<Subject> Subjects = new();
            foreach (var teacherGroup in teacherGroups)
            {
                foreach (var subjectGroup in groupSubjects)
                {
                    if (teacherGroup.GroupId == subjectGroup.GroupId)
                    {
                        Subjects.Add(subjectGroup.Subject);
                    }
                }
            }



            var teacherSubjects = await _context.SubjectTeachers.Include(n => n.Subject).ToListAsync();
            List<Object> groupIds= new();
            foreach (var item in teacherGroups)
            {
                var students = await _context.Students.Where(n => !n.IsDeleted).Where(n => n.GroupId == item.GroupId).ToListAsync();
                foreach (var teacherSubject in teacherSubjects)
                {
                    if (item.TeacherId == teacherSubject.TeacherId )
                    {
                        foreach (var subject in Subjects)
                        {
                            if(teacherSubject.SubjectId == subject.Id)
                            {
                                groupIds.Add(new { id = item.GroupId, item.Group.Name, count = students.Count, subjectName = teacherSubject.Subject.Name,subjectId=teacherSubject.SubjectId });
                            }
                        }
                    }
                }
            }


            return Ok(groupIds);
        }
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    }
}
