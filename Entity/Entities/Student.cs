using Entity.Base;
using Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Student:BaseEntity,IEntity
    {
        public DateTime BirthDay { get; set; }
        public string? FinCode { get; set; }
        public string? Gender { get; set; }
        public string? Division { get; set; }

        public string? BirthLocation { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty? Specialty { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
        public int? SemesterId { get; set; }

        public Semester? Semester { get; set; }

        public ICollection<StudentSubject>? StudentSubjects { get; set; }


    }
}