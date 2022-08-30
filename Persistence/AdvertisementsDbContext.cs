using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence
{
    public class AdvertisementsDbContext : DbContext, IAdvertisementsDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }

        public AdvertisementsDbContext(DbContextOptions<AdvertisementsDbContext> options)
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Advertising>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(advertising => advertising.UserId);
        }
    }
}
