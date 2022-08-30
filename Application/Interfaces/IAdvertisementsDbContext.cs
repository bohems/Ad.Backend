using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAdvertisementsDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Advertising> Advertisings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
