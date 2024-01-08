using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using static BookManagement.Infrastructure.Services.Common;


namespace BookManagement.Application.Manager.Interfaces
{
    public interface IStudentManager
    {
        Task<ServiceResult<bool>> CreateStudent(StudentRequestDTO studentRequestDTO);
        Task<List<ServiceResult<StudentResponseDTO>>> GetStudents();
        Task<ServiceResult<StudentResponseDTO>> GetStudentByID(int id);
        Task<ServiceResult<bool>> UpdateStudent(StudentResponseDTO Student);
        Task<ServiceResult<bool>> DeleteStudent(int id);
    }
}
