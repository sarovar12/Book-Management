using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using static BookManagement.Infrastructure.Services.Common;


namespace BookManagement.Application.Manager.Interfaces
{
    public interface IStudentManager
    {
        Task<ServiceResult<bool>> CreateStudent(StudentRequestDTO studentRequestDTO);
        Task<ServiceResult<List<StudentResponseDTO>>> GetStudents();
        Task<ServiceResult<StudentResponseDTO>> GetStudentByID(Guid id);
        Task<ServiceResult<bool>> UpdateStudent(StudentResponseDTO student);
        Task<ServiceResult<bool>> DeleteStudent(Guid id);
    }
}
