using AutoMapper;
using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Services;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.ImplementingManager
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;

        public StudentManager(IStudentService studentService, IMapper mapper)
        {
            _service = studentService;
            _mapper = mapper;

        }
        public async Task<ServiceResult<bool>> CreateStudent(StudentRequestDTO studentRequestDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            try
            {

                var studentDomain = _mapper.Map<Student>(studentRequestDTO);
                var result = await _service.CreateStudent(studentDomain);
                serviceResult.Status = result ? StatusType.Success : StatusType.Failure;
                serviceResult.Message = result ? "Student Create Successfully" : "Failed to Create Student";
                serviceResult.Data = result;
                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>()
                {
                    Data = false,
                    Status = StatusType.Failure,
                    Message = "Error while creating student"
                };
            }
        }

        public async Task<ServiceResult<bool>> DeleteStudent(Guid id)
        {
            var serviceResult = new ServiceResult<bool>();
            try
            {
                var result = await _service.DeleteStudent(id);
                serviceResult.Status = result ? StatusType.Success : StatusType.Failure;
                serviceResult.Message = result ? "Student Deleted Successfully" : "Failed to Delete student";
                serviceResult.Data = result;
                return serviceResult;

            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>()
                {
                    Data = false,
                    Status = StatusType.Failure,
                    Message = "Error while deleting student"
                };
            }

        }

        public async Task<ServiceResult<StudentResponseDTO>> GetStudentByID(Guid id)
        {
            var serviceResult = new ServiceResult<StudentResponseDTO>();
            try
            {
                var book = await _service.GetStudentByID(id);
                if (book == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Student not found";
                    serviceResult.Data = null;
                    return serviceResult;
                }
                var studentResponse = _mapper.Map<StudentResponseDTO>(book);
                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Student retrieved successfully";
                serviceResult.Data = studentResponse;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while retrieving the book";
                serviceResult.Data = null;

                return serviceResult;

            }
        }

        public async Task<ServiceResult<List<StudentResponseDTO>>> GetStudents()
        {
            var serviceResult = new ServiceResult<List<StudentResponseDTO>>();
            try
            {
                var students = await _service.GetStudents();
                var response = (from student in students
                                where student.DateDeleted == null
                                select new StudentResponseDTO()
                                {
                                    StudentId = student.StudentId,
                                    StudentName = student.StudentName,
                                    Batch = student.Batch,
                                    Faculty = student.Faculty,
                                    RollNo = student.RollNo,
                                }).ToList();

                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Sucessfully retrieved list of students";
                serviceResult.Data = response;
                return serviceResult;
            }

            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occured while fetching students";
                serviceResult.Data = null;
                return serviceResult;

            }
        }

        public async Task<ServiceResult<bool>> UpdateStudent(StudentResponseDTO studentRequestDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            try
            {
                var student = await _service.GetStudentByID(studentRequestDTO.StudentId);
                if (student == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Student could not be found";
                    serviceResult.Data = false;
                    return serviceResult;
                }
                _mapper.Map(studentRequestDTO, student);
                var result = _service.UpdateStudent(student);
                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Student Update Sucessfully";
                serviceResult.Data = true;
                return serviceResult;

            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "An error occurred while retrieving the student";
                serviceResult.Data = false;

                return serviceResult;

            }
        }
    }
}
