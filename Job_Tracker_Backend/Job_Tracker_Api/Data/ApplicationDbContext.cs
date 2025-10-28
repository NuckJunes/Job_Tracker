using Job_Tracker_Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Job_Tracker_Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IConfiguration _config { get; set; }

        public ApplicationDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(a => a.Applications).WithOne(a => a.User);
            
            // Seed All Data From Below Here //

            
        }
    }
}