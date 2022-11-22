using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_course_management.Dtos.Course;
using dotnet_course_management.Dtos.Student;
using dotnet_course_management.Models;

namespace dotnet_course_management
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, GetStudentDto>();
            CreateMap<AddStudentDto, Student>();

            CreateMap<Course, GetCourseDto>();
            CreateMap<AddCourseDto, Course>();
        }
    }
}