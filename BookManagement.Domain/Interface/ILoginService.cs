
using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interface
{
    public interface ILoginService
    {
        Task<Staff> GetStaffByUsername(string username);
        Task<bool> ResetPassword (Staff staff);

    }
}
