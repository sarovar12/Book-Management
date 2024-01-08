using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Repository
{
    public class ServiceRepository<t> : IServiceRepository<t>, IDisposable where t : class
    {
        DatabaseContext db;
        DbSet<t> entity;

        public ServiceRepository()
        {
            db = new DatabaseContext();
            entity = db.Set<t>();
        }
        public ServiceRepository(DatabaseContext db)
        {
            this.db = db;
            entity = db.Set<t>();
        }
        public Task<t> AddAsync(t model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(List<t> model)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<t> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<t>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(t model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveRangeAsync(List<t> model)
        {
            throw new NotImplementedException();
        }

        public Task<t> UpdateAsync(t model)
        {
            throw new NotImplementedException();
        }
    }
}
