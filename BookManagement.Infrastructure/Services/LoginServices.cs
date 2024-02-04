

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Repository;

namespace BookManagement.Infrastructure.Services
{
    
    public class LoginServices : ILoginService
    {
        private readonly IServiceFactory _factory;
        public LoginServices(IServiceFactory serviceFactory)
        {
            _factory = new ServiceFactory();

        }

        public async Task<Staff> GetStaffByUsername(string username)
        {
            var staffs = await _factory.GetInstance<Staff>().ListAsync();
            var user = staffs.FirstOrDefault(x => x.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            return user;
        }

        public Task<bool> ResetPassword(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
