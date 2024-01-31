using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.Interfaces
{
    public interface IStaffManager
    {
        Task<ServiceResult<bool>> AddStaff(StaffRequestDTO staffRequestDTO);
        Task<ServiceResult<bool>> DeleteStaff(Guid id);
        Task<ServiceResult<StaffResponseDTO>> GetStaffById(Guid id);
        Task<ServiceResult<List<StaffResponseDTO>>> GetStaffs();
        Task<ServiceResult<bool>> UpdateStaffs(StaffResponseDTO staffResponseDTO);
    }
}
