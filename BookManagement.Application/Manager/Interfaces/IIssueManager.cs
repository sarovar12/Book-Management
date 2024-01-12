using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.Interfaces
{
    public interface IIssueManager
    {
        Task<ServiceResult<bool>> AddIssue(IssueRequestDTO issueRequestDTO);
        Task<ServiceResult<bool>> DeleteIssue(Guid id);
        Task<ServiceResult<IssueResponseDTO>> GetIssueById(Guid id);
        Task<ServiceResult<List<IssueResponseDTO>>> GetIssues();
        Task<ServiceResult<bool>> UpdateIssue(IssueResponseDTO issueResponseDTO);
        Task<ServiceResult<bool>> ReturnIssuedBook(IssueResponseDTO issueResponseDTO);
    }
}

