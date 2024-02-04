using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Repository;

namespace BookManagement.Infrastructure.Services
{
    public class StaffServices : IStaffService
    {
        private readonly IServiceFactory _factory;
        public StaffServices(IServiceFactory serviceFactory)
        {
            _factory = new ServiceFactory();
        }
        public async Task<bool> AddStaff(Staff staff)
        {
            try
            {
                var service = _factory.GetInstance<Staff>();
                await service.AddAsync(staff);
                return true;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> DeleteStaff(Guid id)
        {
            try
            {
                var service = _factory.GetInstance<Staff>();
                var staff = await service.FindAsync(id);
                if (staff == null)
                {
                    return false;
                }
                staff.DateDeleted = DateTime.Now;
                await service.UpdateAsync(staff);
                return true;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Staff> GetStaffById(Guid id)
        {
            var service = _factory.GetInstance<Staff>();
            var staffs = await service.ListAsync();
            var bookById = staffs.FirstOrDefault(staff => staff.StaffId == id && staff.DateDeleted == null);
            if (bookById == null)
            {
                return null;
            }
            return bookById;

        }

        public async Task<List<Staff>> GetStaffs()
        {
            try
            {
                var service = _factory.GetInstance<Staff>();
                var staffs = await service.ListAsync();
                return staffs;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> UpdateStaff(Staff staff)
        {
            try
            {
                var service = _factory.GetInstance<Staff>();
                var staffData = await service.FindAsync(staff.StaffId);
                if (staffData == null || staff.DateDeleted.HasValue)
                {
                    return false;
                }
                staffData.StaffType = staff.StaffType;
                staffData.Username = staff.Username;
                await service.UpdateAsync(staffData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IsUniqueUsername(string username)
        {
            try
            {
                var staff = await _factory.GetInstance<Staff>().ListAsync();
                var result = staff.Where(staff => staff.Username == username).Any();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
