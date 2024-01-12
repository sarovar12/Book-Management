using Microsoft.EntityFrameworkCore;


namespace BookManagement.Infrastructure.Repository
{
    public class ServiceRepository<t> : IServiceRepository<t> where t : class
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
        public async Task<t> AddAsync(t model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            try
            {
                var newEntity= await entity.AddAsync(model);
                var newEntityToReturn = newEntity.Entity;
                db.SaveChanges();
                return newEntityToReturn;

  
            }catch (DbUpdateException exception)
            {
                throw;
            }
        }

        public async Task<bool> AddRangeAsync(List<t> model)
        {
            try
            {
                await entity.AddRangeAsync(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public async Task<t> FindAsync(int id)
        {
            var newEntity = await entity.FindAsync(id);
            return newEntity;
        }

        public async Task<t> FindAsync(Guid id)
        {
            var newEntity = await entity.FindAsync(id);
            return newEntity;
        }

        public async Task<List<t>> ListAsync()
        {
            var result = await entity.AsNoTracking().ToListAsync();
            return result;
       }

        public async Task<bool> RemoveAsync(t model)
        {
            try
            {
                entity.RemoveRange(model);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception wx)
            {
                return false;
            }
        }

        public Task<bool> RemoveRangeAsync(List<t> model)
        {
            throw new NotImplementedException();
        }

        public async Task<t> UpdateAsync(t model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                db.ChangeTracker.Clear();
                var newEntity = entity.Update(model);
                var newEntityToRet = newEntity.Entity;
                await db.SaveChangesAsync();

                return newEntityToRet;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw;
            }
        }
       
    }

    public class ServiceFactory : IServiceFactory
    {
        public DatabaseContext db;
        public bool _isforTest;


        public ServiceFactory()
        {
            db = new DatabaseContext();
        }
        public ServiceFactory(DatabaseContext db, bool isforTest)
        {
            this.db = db;
            this._isforTest = isforTest;
        }
          public IServiceRepository<t> GetInstance<t>() where t : class
        {
            return new ServiceRepository<t>(db);
        }

        public void BeginTransaction()
        {
            this.db.Database.BeginTransaction();
        }
        public void RollBack()
        {
            this.db.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            this.db.Database.CommitTransaction();
        }

        public void WriteLog(string message, object exception, string v)
        {
            // throw new NotImplementedException();
        }

    }
}
