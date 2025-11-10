using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Job_Tracker_Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
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
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<User>().HasMany(a => a.Applications).WithOne(a => a.User);

            // Seed All Data From Below Here //


        }
        
        // public void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
        //     services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
        //     services.AddControllers();
        // }
    }
}