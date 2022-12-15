using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Data;
using dotnet_course_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_course_management.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BasicUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public BasicUsersController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingle(int id)
        {
            return Ok(await _context.Users.FindAsync(id));
        }
    }
}