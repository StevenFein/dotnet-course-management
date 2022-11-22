using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_course_management.Dtos.Course;
using dotnet_course_management.Models;

namespace dotnet_course_management.Services.CourseService
{
    public class CourseService : ICourseService
    {
        
        private static List<Course> courses = new List<Course>{
            new Course(),
            new Course{Id = 1, Name = "English 101", Description = "Learn the fundamentals of how to read this sentence", Units = 3}
        };
        private readonly IMapper _mapper;
        public CourseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCourseDto>>> AddCourse(AddCourseDto newCourse)
        {
            var serviceResponse = new ServiceResponse<List<GetCourseDto>>();
            Course course = _mapper.Map<Course>(newCourse);
            course.Id = courses.Max( c=> c.Id) + 1;
            courses.Add(course);
            serviceResponse.Data = courses.Select(c=> _mapper.Map<GetCourseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCourseDto>>> DeleteCourse(int id)
        {
            ServiceResponse<List<GetCourseDto>> response = new ServiceResponse<List<GetCourseDto>>();
            try
            {
            Course course = courses.First(c => c.Id == id);
            courses.Remove(course);
            response.Data = courses.Select(c=> _mapper.Map<GetCourseDto>(c)).ToList();
            
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCourseDto>>> GetAllCourses()
        {
            return new ServiceResponse<List<GetCourseDto>>{Data = courses.Select(c=> _mapper.Map<GetCourseDto>(c)).ToList()};
        }

        public async Task<ServiceResponse<GetCourseDto>> GetCourseById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCourseDto>();
            var course = courses.FirstOrDefault(c=> c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCourseDto>(course);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCourseDto>> UpdateCourse(UpdateCourseDto updatedCourse)
        {
            ServiceResponse<GetCourseDto> response = new ServiceResponse<GetCourseDto>();
            try
            {
            Course course = courses.FirstOrDefault(c => c.Id == updatedCourse.Id);

            course.Name = updatedCourse.Name;
            course.Description = updatedCourse.Description;
            course.Units = updatedCourse.Units;

            response.Data = _mapper.Map<GetCourseDto>(course);
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}