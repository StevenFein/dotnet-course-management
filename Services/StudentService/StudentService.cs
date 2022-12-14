using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_course_management.Dtos.Student;
using dotnet_course_management.Models;

namespace dotnet_course_management.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>{
            new Student(),
            new Student {Id = 1, FirstName = "SpongeBob", LastName = "SquarePants"}
        };
        private readonly IMapper _mapper;

        public StudentService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            Student student = _mapper.Map<Student>(newStudent);
            student.Id = students.Max(c => c.Id) + 1;
            students.Add(student);
            serviceResponse.Data = students.Select(c => _mapper.Map<GetStudentDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id)
        {
            ServiceResponse<List<GetStudentDto>> response = new ServiceResponse<List<GetStudentDto>>();
            try
            {
            Student student = students.First(c => c.Id == id);
            students.Remove(student);
            response.Data = students.Select(c => _mapper.Map<GetStudentDto>(c)).ToList();
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            return new ServiceResponse<List<GetStudentDto>> { Data = students.Select(c => _mapper.Map<GetStudentDto>(c)).ToList() };
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();
            var student = students.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetStudentDto>(student);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();
            try
            {
            Student student = students.FirstOrDefault(c => c.Id == updatedStudent.Id);
            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;

            response.Data = _mapper.Map<GetStudentDto>(student);
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}