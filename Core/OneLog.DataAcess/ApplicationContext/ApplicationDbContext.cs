using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneLog.Domain.Entities;

namespace OneLog.DataAccess.ApplicationContext
{

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<BusinessApplication> Applications { get; set; }

    }
}