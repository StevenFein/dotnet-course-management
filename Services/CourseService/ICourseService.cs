using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Dtos.Course;
using dotnet_course_management.Models;

namespace dotnet_course_management.Services.CourseService
{
    public interface ICourseService
    {
        Task<ServiceResponse<List<GetCourseDto>>> GetAllCourses();
        Task<ServiceResponse<GetCourseDto>> GetCourseById(int id);
        Task<ServiceResponse<List<GetCourseDto>>> AddCourse(AddCourseDto newCourse);
        Task<ServiceResponse<GetCourseDto>> UpdateCourse(UpdateCourseDto updatedCharacter);
        Task<ServiceResponse<List<GetCourseDto>>> DeleteCourse(int id);
    }
}