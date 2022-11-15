using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_course_management.Models;

namespace dotnet_course_management.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>{
            new Student(),
            new Student {Id = 1, FirstName = "SpongeBob", LastName = "SquarePants"}
        };
        public async Task<ServiceResponse<List<Student>>> AddStudent(Student newStudent)
        {
            var serviceResponse = new ServiceResponse<List<Student>>();
            students.Add(newStudent);
            serviceResponse.Data = students;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Student>>> GetAllStudents()
        {
            return new ServiceResponse<List<Student>> { Data = students };
        }

        public async Task<ServiceResponse<Student>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<Student>();
            var student = students.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = student;
            return serviceResponse;
        }
    }
}