using AutoMapper;
using Entity.DTOS.Course;
using Entity.DTOS.Event;
using Entity.DTOS.Graduate;
using Entity.DTOS.Group;
using Entity.DTOS.News;
using Entity.DTOS.Slider;
using Entity.DTOS.Specialty;
using Entity.DTOS.Subject;
using Entity.DTOS.Teacher;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Profiles
{
    public class Mapper:Profile
    {
        public List<string> getImageNames(News news)
        {
            List<string> imageNames = new();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var image in news.NewsImages)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                imageNames.Add(image.Image.Name);
#pragma warning restore CS8604 // Possible null reference argument.
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return imageNames;
        }
        public List<string> getImageNames(Event events)
        {
            List<string> imageNames = new();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var image in events.ImageEvents)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                imageNames.Add(image.Image.Name);
#pragma warning restore CS8604 // Possible null reference argument.
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return imageNames;
        }
        public Mapper()
        {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            CreateMap<Slider, SliderGetDto>()
            .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
            .ForMember(n => n.Title, n => n.MapFrom(n => n.Title))
            .ForMember(n => n.Content, n => n.MapFrom(n => n.Content))
            .ForMember(n => n.ImageName, n => n.MapFrom(n => n.Image.Name));

#pragma warning disable CS8604 // Possible null reference argument.
            CreateMap<News, NewsGetDto>()
                .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
                .ForMember(n => n.Title, n => n.MapFrom(n => n.Title))
                .ForMember(n => n.Content, n => n.MapFrom(n => n.Content))
                .ForMember(n => n.ImageNames, n => n.MapFrom(n => getImageNames(n)));
#pragma warning restore CS8604 // Possible null reference argument.
            CreateMap<Graduate, GraduateGetDto>()
                .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
                .ForMember(n => n.Name, n => n.MapFrom(n => n.Name))
                .ForMember(n => n.Info, n => n.MapFrom(n => n.Info))
                .ForMember(n => n.ImageName, n => n.MapFrom(n => n.Image.Name))
                .ForMember(n => n.StartEducation, n => n.MapFrom(n => n.StartEducation));


            CreateMap<Event, EventGetDto>()
              .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
              .ForMember(n => n.Venue, n => n.MapFrom(n => n.Venue))
              .ForMember(n => n.Cost, n => n.MapFrom(n => n.Cost))
              .ForMember(n => n.Description, n => n.MapFrom(n => n.Description))
              .ForMember(n => n.Type, n => n.MapFrom(n => n.Type))
              .ForMember(n => n.ImageNames, n => n.MapFrom(n => getImageNames(n)))
              .ForMember(n => n.CreatedDate, n => n.MapFrom(n => n.CreatedDate));

            CreateMap<Course,CourseGetDto>()
                     .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
              .ForMember(n => n.CourseYear, n => n.MapFrom(n => n.CourseYear));

            CreateMap<Group, GroupGetDto>()
                   .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
              .ForMember(n => n.GroupName, n => n.MapFrom(n => n.Name))
              .ForMember(n => n.FacultyName, n => n.MapFrom(n => n.Specialty.Faculty.Name))
              .ForMember(n => n.SpecialtyName, n => n.MapFrom(n => n.Specialty.Name))
              .ForMember(n => n.CreateadDate, n => n.MapFrom(n => n.CreatedDate));
            CreateMap<Subject, SubjectGetDto>()
       .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
  .ForMember(n => n.Name, n => n.MapFrom(n => n.Name));


            CreateMap<Specialty, SpecialtyGetDto>()
       .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
  .ForMember(n => n.Name, n => n.MapFrom(n => n.Name))
  .ForMember(n=>n.FacultyName,n=>n.MapFrom(n=>n.Faculty.Name))
  .ForMember(n=>n.CreatedDate,n=>n.MapFrom(n=>n.CreatedDate));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            //#pragma warning disable CS8602 // Dereference of a possibly null reference.
            //            CreateMap<SliderCreateDto, Slider>()
            //                .ForMember(n => n.Title, n => n.MapFrom(n => n.Title))
            //                .ForMember(n => n.Content, n => n.MapFrom(n => n.Content))
            //                .ForMember(n => n.Image.Name, n => n.MapFrom(n => n.ImageUrl));
            //#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
