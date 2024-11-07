using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace DAL.Management
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>();
            modelBuilder.Entity<Employee>();
        }
    }
}
