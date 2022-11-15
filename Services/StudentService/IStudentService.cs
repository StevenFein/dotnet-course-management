using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Models;

namespace dotnet_course_management.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<Student>>> GetAllStudents();
        Task<ServiceResponse<Student>> GetStudentById(int id);
        Task<ServiceResponse<List<Student>>> AddStudent(Student newStudent);
    }
}