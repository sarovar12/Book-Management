using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Services
{
    public class StudentServices : IStudentService
    {
        private readonly IServiceFactory _factory;

        public StudentServices(IServiceFactory serviceFactory)
        {
            _factory = serviceFactory;

        }

        public async Task<bool> CreateStudent(Student student)
        {
            try
            {
                var service = _factory.GetInstance<Student>();
                await service.AddAsync(student);
                return true;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            try
            {
                var service = _factory.GetInstance<Student>();
                var student = await service.FindAsync(id);
                if (student == null)
                {
                    return false;
                }
                student.DateDeleted = DateTime.Now;
                await service.UpdateAsync(student);
                return true;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Student> GetStudentByID(Guid id)
        {
            var service = _factory.GetInstance<Student>();
            var students = await service.ListAsync();
            var studentById = students.FirstOrDefault(student => student.StudentId == id && student.DateDeleted == null);
            if (studentById == null)
            {
                return null;
            }
            return studentById;
        }

        public async Task<List<Student>> GetStudents()
        {
            var service = _factory.GetInstance<Student>();
            var students = await service.ListAsync();
            return students;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            try
            {
                var service = _factory.GetInstance<Student>();
                var studentData = await service.FindAsync(student.StudentId);
                if (studentData == null || studentData.DateDeleted.HasValue)
                {
                    return false;
                }
                studentData.StudentName = student.StudentName;
                studentData.Faculty = student.Faculty;
                studentData.Batch = student.Batch;
                studentData.RollNo = student.RollNo;

                await service.UpdateAsync(studentData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
