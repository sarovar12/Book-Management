

using BookManagement.Application.DTO.Request;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.Interfaces
{
    public interface ILoginManager
    {
        Task<ServiceResult<string>> GetJWTToken(LoginRequestDTO loginRequestDTO);

    }
}
