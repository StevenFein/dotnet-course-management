using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_course_management.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<User> Users => Set<User>();
    }
}