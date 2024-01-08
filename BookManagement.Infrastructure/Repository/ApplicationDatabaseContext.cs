using BookManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repository
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Student> Students { get; set; }



    }
}
