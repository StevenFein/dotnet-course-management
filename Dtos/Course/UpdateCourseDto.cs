using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_course_management.Dtos.Course
{
    public class UpdateCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Units { get; set; }
        public int UserId { get; set; }
    }
}