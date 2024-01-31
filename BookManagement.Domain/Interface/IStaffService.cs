using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Interface
{
    public interface IStaffService
    {
        Task<bool> AddStaff(Staff staff);
        Task<List<Staff>> GetStaffs();
        Task<Staff> GetStaffById(Guid id);
        Task<bool> UpdateStaff(Staff staff);
        Task<bool> DeleteStaff(Guid id);
        Task<bool> IsUniqueUsername(string username);
    }
}
