using AutoMapper;
using DAL.DATA;
using Entity.DTOS.Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDU_API.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class SubjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SubjectController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var data = await _context.Subjects.Where(n => !n.IsDeleted).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            var dto = _mapper.Map<List<SubjectGetDto>>(data);
            return Ok(dto);
        }

        [HttpGet, Route("{id}/{courseId}/{semesterId}/{groupId}")]
        public async Task<IActionResult> ForSpecialtyId(int id, int courseId, int semesterId,int groupId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            //var specialtySubjects = await _context.SpecialtySubjects.Where(n => n.SpecialtyId == id).Include(n => n.Subject).ThenInclude(n => n.SubjectCourses).ThenInclude(n => n.Course).Include(n=>n.Subject).ThenInclude(n=>n.SubjectSemesters).ToListAsync();
            var subjectGroups = await _context.SubjectGroups.Where(n => n.GroupId == groupId).Include(n=>n.Subject).ThenInclude(n=>n.SubjectCourses).ThenInclude(n=>n.Course).Include(n=>n.Subject).ThenInclude(n=>n.SubjectSemesters).ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            List<Object> datas = new();
            //foreach (var item in specialtySubjects)
            //{
            //    foreach (var item2 in item.Subject.SubjectCourses)
            //    {
            //        if (item2.Course.Id == courseId)
            //        {
            //            foreach (var subjectSemester in item2?.Subject?.SubjectSemesters)
            //            {
            //                if (subjectSemester.SemesterId == semesterId)
            //                {

            //                    datas.Add(new { id = item.Subject.Id, name = item.Subject.Name });

            //                }
            //            }

            //        }
            //    }

            //}

            foreach (var subjectGroup in subjectGroups)
            {
                foreach (var subjectCourse in subjectGroup.Subject.SubjectCourses)
                {
                    if (subjectCourse.CourseId == courseId)
                    {
                        foreach (var subjectSemester in subjectCourse.Subject.SubjectSemesters)
                        {
                            if (subjectSemester.SemesterId == semesterId)
                            {
                                datas.Add(new { id=subjectGroup.SubjectId, name = subjectGroup.Subject.Name });
                            }
                        }
                    }
                }
            }


     
            return Ok(datas);


        }


        [HttpGet, Route("{id}/{courseId}/")]
        public async Task<IActionResult> ForSpecialtyId(int id, int courseId)
        {
            var dat = await _context.SpecialtySubjects.ToListAsync();
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var specialtySubjects = await _context.SpecialtySubjects.Where(n => n.SpecialtyId == id).Include(n => n.Subject).ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            List<Object> datas = new();
            foreach (var item in specialtySubjects)
            {
                datas.Add(new {id=item.SubjectId, name=item.Subject.Name});

            }
            return Ok(datas);
        }

        //[HttpGet, Route("{id}/{groupid}")]
        //public async Task<IActionResult> GetForAppUserId(string id, int groupid)
        //{
        //    var teacher = await _context.Teachers.Where(n => n.AppUserId == id).Include(n => n.AppUser).FirstOrDefaultAsync();
        //    var teacherSubject = await _context.StudentTeachers.Where(n => n.TeacherId == teacher.Id).ToListAsync();
        //    var teacherGroup = await _context.TeacherGroups.Where(n => n.TeacherId == teacher.Id && n.GroupId == groupid).FirstOrDefaultAsync();

        //}
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.