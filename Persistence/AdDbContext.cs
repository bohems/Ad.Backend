using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence
{
    public class AdDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }

        public AdDbContext(DbContextOptions<AdDbContext> options)
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
