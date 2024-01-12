using BookManagement.Domain.Entities;


namespace BookManagement.Domain.Interface
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(Student student);
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentByID(Guid id);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(Guid id);
    }
}
