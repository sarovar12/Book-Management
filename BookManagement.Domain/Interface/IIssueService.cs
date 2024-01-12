using BookManagement.Domain.Entities;


namespace BookManagement.Domain.Interface
{
    public interface IIssueService
    {
        Task<bool> AddIssuedService(Issue issue);
        Task<List<Issue>> GetIssuedServices();
        Task<Issue> GetIssuedServiceById(Guid id);
        Task<bool> UpdateIssuedService(Issue issue);
        Task<bool> DeleteIssuedService(Guid id);
    }
}
