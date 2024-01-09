using BookManagement.Domain.Entities;


namespace BookManagement.Domain.Interface
{
    public interface IIssueService
    {
        Task<bool> AddIssuedService(Issue issue);
        Task<List<Issue>> GetIssuedServices();
        Task<Issue> GetIssuedServiceById(int id);
        Task<bool> UpdateIssuedService(Book book);
        Task<bool> DeleteIssuedService(int id);
    }
}
