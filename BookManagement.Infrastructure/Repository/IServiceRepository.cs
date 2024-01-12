

namespace BookManagement.Infrastructure.Repository
{
    public interface IServiceRepository<t>
    {
        Task<t> FindAsync(int id);
        Task<t> FindAsync(Guid id);
        Task<t> AddAsync(t model);

        Task<List<t>> ListAsync();

        Task<t> UpdateAsync(t model);

        Task<bool> AddRangeAsync(List<t> model);

        Task<bool> RemoveRangeAsync(List<t> model);

        Task<bool> RemoveAsync(t model);



    }
}
