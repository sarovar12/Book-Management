using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Repository;

namespace BookManagement.Infrastructure.Services
{
    public class IssueServices : IIssueService
    {
        private readonly IServiceFactory _factory;

        public IssueServices(IServiceFactory factory)
        {
            _factory = factory;

        }
        public async Task<bool> AddIssuedService(Issue issue)
        {
            if (issue == null)
            {
                return false;
            }
            else
            {
                var service = _factory.GetInstance<Issue>();
                await service.AddAsync(issue);
                return true;
            }
        }

        public async Task<bool> DeleteIssuedService(Guid id)
        {
            var service = _factory.GetInstance<Issue>();
            var issue = await service.FindAsync(id);
            if (issue == null)
            {
                return false;
            }

            await service.RemoveAsync(issue);
            return true;
        }

        public async Task<Issue> GetIssuedServiceById(Guid id)
        {
            var service = _factory.GetInstance<Issue>();
            var issues = await service.ListAsync();
            var issueById = issues.FirstOrDefault(issue => issue.IssueId == id && issue.DateDeleted == null);
            if (issueById == null)
            {
                return null;
            }
            return issueById;
        }

        public async Task<List<Issue>> GetIssuedServices()
        {
            try
            {
                var service = _factory.GetInstance<Issue>();
                var issues = await service.ListAsync();
                return issues;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> UpdateIssuedService(Issue issue)
        {
            try
            {
                var service = _factory.GetInstance<Issue>();
                var issueData = await service.FindAsync(issue.IssueId);
                if (issue == null || issueData.DateDeleted.HasValue)
                {
                    return false;
                }
                issueData.ReturnedDate = issue.ReturnedDate;
                issueData.BookId = issue.BookId;
                issueData.StudentId = issue.StudentId;
                issueData.IsAvailable = issue.IsAvailable;
                issueData.Fine = issue.Fine;
                issueData.DateDeleted = issue.DateDeleted;
                issueData.IssuerName = issue.IssuerName;
                await service.UpdateAsync(issueData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
