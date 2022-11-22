using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_course_management.Models;
using dotnet_course_management.Services.CourseService;
using dotnet_course_management.Dtos.Course;

namespace dotnet_course_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
            
        }
        [HttpGet("GetAllCourses")]
        public async Task<ActionResult<ServiceResponse<List<GetCourseDto>>>> Get()
        {
            return Ok(await _courseService.GetAllCourses());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCourseDto>>> GetSingle(int id)
        {
            return Ok(await _courseService.GetCourseById(id));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCourseDto>>>> Delete(int id)
        {
            var response = await _courseService.DeleteCourse(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCourseDto>>>> AddCourse(AddCourseDto newCourse)
        {
            return Ok(await _courseService.AddCourse(newCourse));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCourseDto>>> UpdateCourse(UpdateCourseDto updatedCourse)
        {
            var response = await _courseService.UpdateCourse(updatedCourse);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
    }
}