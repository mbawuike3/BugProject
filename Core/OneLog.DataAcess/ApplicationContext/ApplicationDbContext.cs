using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OneLog.Domain.Entities;
using System;

namespace OneLog.DataAccess.ApplicationContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Business>()
                .HasOne(b => b.Country)
                .WithMany()
                .HasForeignKey(b => b.CountryId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<BusinessApplication>()
                .HasOne(ba => ba.Business)
                .WithMany()
                .HasForeignKey(ba => ba.BusinessId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Log>()
                .HasOne(L => L.Business)
                .WithMany()
                .HasForeignKey(L => L.BusinessId)
                .OnDelete(DeleteBehavior.NoAction);


        }


        public DbSet<Business> Businesses { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<BusinessApplication> Applications { get; set; }
    }
}
