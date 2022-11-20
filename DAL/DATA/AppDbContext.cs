using Entity.Configurations;
using Entity.Entities;
using Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DATA
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Image>? Images { get; set; }

        public DbSet<Slider>? Sliders { get; set; }

        public DbSet<News>? News { get; set; }

        public DbSet<NewsImage>? NewsImages { get; set; }

        public DbSet<Graduate>? Graduates { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<Dekan>? Dekans { get; set; }

        public DbSet<Event>? Events { get; set; }

        public DbSet<Faculty>? Faculties { get; set; }

        public DbSet<Group>? Groups { get; set; }

        public DbSet<ProRektor>? ProRektors { get; set; }

        public DbSet<Rektor>? Rektors { get; set; }

        public DbSet<Semester>? Semesters { get; set; }

        public DbSet<Specialty>? Specialties { get; set; }

        public DbSet<Subject>? Subjects { get; set; }

        public DbSet<SpecialtySubject>? SpecialtySubjects { get; set; }

        public DbSet<Student>? Students { get; set; }

        public DbSet<Teacher>? Teachers { get; set; }

        public DbSet<StudentTeacher>? StudentTeachers { get; set; }

        public DbSet<SubjectTeacher>? SubjectTeachers { get; set; }

        public DbSet<TeacherGroup>? TeacherGroups { get; set; }
        

        public DbSet<EventImage>? EventImages { get; set; }

        public DbSet<SubjectCourse>? SubjectCourses { get; set; }

        public DbSet<SubjectSemester>? SubjectSemesters { get; set; }

        public DbSet<Kollekvum>? Kollekvums { get; set; }

        public DbSet<SerbestIs>? SerbestIss { get; set; }

        public DbSet<StudentSubject>? StudentSubjects { get; set; }

        public DbSet<SubjectSerbesIsStudent>? SubjectSerbesIsStudents { get; set; }

        public DbSet<SubjectKollekvumStudent>? SubjectKollekvumStudents { get; set; }

        public DbSet<SubjectGroups>? SubjectGroups { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfigurations());

            base.OnModelCreating(builder);
        }
        

    }
}
