using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Data;
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

        [HttpPost("CreateCourse")]
        public async Task<ActionResult<List<Course>>> CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpPut("UpdateCourse")]
        public async Task<ActionResult<List<Course>>> UpdateCourse(Course course)
        {
            var dbCourse = await _context.Courses.FindAsync(course.Id);
            if(dbCourse == null)
            {
                return BadRequest("Course Not Found");
            }
            dbCourse.Name = course.Name;
            dbCourse.Description = course.Description;
            dbCourse.Units = course.Units;

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

            _context.Courses.Remove(dbCourse);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }
    }
}