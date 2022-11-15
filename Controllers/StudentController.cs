using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_course_management.Models;
using dotnet_course_management.Services.StudentService;

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
        public async Task<ActionResult<ServiceResponse<List<Student>>>> Get()
        {
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Student>>> GetSingle(int id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Student>>>> AddStudent(Student newStudent)
        {
            return Ok(await _studentService.AddStudent(newStudent));
        }
    }
}