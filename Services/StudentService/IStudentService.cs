using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Dtos.Student;
using dotnet_course_management.Models;

namespace dotnet_course_management.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents();
        Task<ServiceResponse<GetStudentDto>> GetStudentById(int id);
        Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent);
    }
}