using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_course_management.Models;
using dotnet_course_management.Services.StudentService;
using dotnet_course_management.Dtos.Student;

namespace dotnet_course_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
       
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            
        }
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> Get()
        {
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> GetSingle(int id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> Delete(int id)
        {
            var response = await _studentService.DeleteStudent(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> AddStudent(AddStudentDto newStudent)
        {
            return Ok(await _studentService.AddStudent(newStudent));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            var response = await _studentService.UpdateStudent(updatedStudent);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}