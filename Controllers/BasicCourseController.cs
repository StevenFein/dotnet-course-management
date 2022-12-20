using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Data;
using dotnet_course_management.Dtos.Course;
using dotnet_course_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_course_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasicCourseController : ControllerBase
    {
        private readonly DataContext _context;

        public BasicCourseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllCourses")]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            return Ok(await _context.Courses.ToListAsync());
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Course>>> GetUsersCourses(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user == null){
                return NotFound();
            }
            
            return Ok(await _context.Courses.Where(c => c.UserId == userId).ToListAsync());
        }

        [HttpPost("CreateCourse")]
        public async Task<ActionResult<List<Course>>> CreateCourse(AddCourseDto courseDto)
        {
            var user = await _context.Users.FindAsync(courseDto.UserId);
            if(user == null){
                return NotFound();
            }

            var newCourse = new Course{
                Name = courseDto.Name,
                Description = courseDto.Description,
                Units = courseDto.Units,
                User = user
            };
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.Where(c => c.UserId == courseDto.UserId).ToListAsync());
        }
        [HttpPost("OldCreateCourse")]
        public async Task<ActionResult<List<Course>>> OldCreateCourse(AddCourseDto courseDto)
        {
            var user = await _context.Users.FindAsync(1);
            if(user == null){
                return NotFound();
            }

            var newCourse = new Course{
                Name = courseDto.Name,
                Description = courseDto.Description,
                Units = courseDto.Units,
                User = user
            };
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpPut("UpdateCourse")]
        public async Task<ActionResult<List<Course>>> UpdateCourse(UpdateCourseDto course)
        {
            var dbCourse = await _context.Courses.FindAsync(course.Id);
            if(dbCourse == null)
            {
                return BadRequest("Course Not Found");
            }
            dbCourse.Name = course.Name;
            dbCourse.Description = course.Description;
            dbCourse.Units = course.Units;
            dbCourse.UserId = course.UserId;

            await _context.SaveChangesAsync();
            return Ok(await _context.Courses.Where(c => c.UserId == course.UserId).ToListAsync());
        }
        [HttpPut("OldUpdateCourse")]
        public async Task<ActionResult<List<Course>>> OldUpdateCourse(UpdateCourseDto course)
        {
            var dbCourse = await _context.Courses.FindAsync(course.Id);
            if(dbCourse == null)
            {
                return BadRequest("Course Not Found");
            }
            dbCourse.Name = course.Name;
            dbCourse.Description = course.Description;
            dbCourse.Units = course.Units;
            dbCourse.UserId = course.UserId;

            await _context.SaveChangesAsync();
            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Course>>> DeleteCourse(int id)
        {
            var dbCourse = await _context.Courses.FindAsync(id);
            if(dbCourse == null)
            {
                return BadRequest("Course Not Found");
            }
            var user = await _context.Users.FindAsync(dbCourse.UserId);

            _context.Courses.Remove(dbCourse);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.Where(c => c.UserId == user.Id).ToListAsync());
        }
        [HttpDelete("Old{id}")]
        public async Task<ActionResult<List<Course>>> OldDeleteCourse(int id)
        {
            var dbCourse = await _context.Courses.FindAsync(id);
            if(dbCourse == null)
            {
                return BadRequest("Course Not Found");
            }

            _context.Courses.Remove(dbCourse);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }
    }
}