using BookManagement.Domain.Entities;


namespace BookManagement.Application.Interface
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(Student student);
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentByID(int id);
        Task<bool> UpdateStudent(Student Student);
        Task<bool> DeleteStudent(int id);
    }
}
