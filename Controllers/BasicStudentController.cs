using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Data;
using dotnet_course_management.Dtos.Student;
using dotnet_course_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_course_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasicStudentController : ControllerBase
    {
        private readonly DataContext _context;
        public BasicStudentController(DataContext context)
        {
            _context = context;
            
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return Ok(await _context.Students.ToListAsync());
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Course>>> GetUsersStudents(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user == null){
                return NotFound();
            }
            
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<List<Student>>> CreateStudent(AddStudentDto studentDto)
        {
            var user = await _context.Users.FindAsync(studentDto.UserId);
            if(user == null){
                return NotFound();
            }

            var newStudent = new Student{
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                User = user
            };
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.Where(c => c.UserId == studentDto.UserId).ToListAsync());
        }
        [HttpPost("OldCreateStudent")]
        public async Task<ActionResult<List<Student>>> OldCreateStudent(AddStudentDto studentDto)
        {
            var user = await _context.Users.FindAsync(1);
            if(user == null){
                return NotFound();
            }

            var newStudent = new Student{
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                User = user
            };
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(UpdateStudentDto student)
        {
            var dbStudent = await _context.Students.FindAsync(student.Id);
            if(dbStudent == null)
            {
                return BadRequest("Student Not Found");
            }
            dbStudent.FirstName = student.FirstName;
            dbStudent.LastName = student.LastName;
            dbStudent.UserId = student.UserId;

            await _context.SaveChangesAsync();
            return Ok(await _context.Students.Where(c => c.UserId == student.UserId).ToListAsync());
        }
        [HttpPut("OldUpdateStudent")]
        public async Task<ActionResult<List<Student>>> OldUpdateStudent(UpdateStudentDto student)
        {
            var dbStudent = await _context.Students.FindAsync(student.Id);
            if(dbStudent == null)
            {
                return BadRequest("Student Not Found");
            }
            dbStudent.FirstName = student.FirstName;
            dbStudent.LastName = student.LastName;
            dbStudent.UserId = student.UserId;

            await _context.SaveChangesAsync();
            return Ok(await _context.Students.Where(c => c.UserId == student.UserId).ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var dbStudent = await _context.Students.FindAsync(id);
            if(dbStudent == null)
            {
                return BadRequest("Student Not Found");
            }
            var user = await _context.Users.FindAsync(dbStudent.UserId);

            _context.Students.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.Where(c => c.UserId == user.Id).ToListAsync());
        }
    }

}