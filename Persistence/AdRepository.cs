using Domain;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AdRepository : IAdRepository
    {
        private readonly AppDbContext _context;

        public AdRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ad> GetAdByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Ads.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public IQueryable<Ad> GetAllAds()
        {
            return _context.Ads.AsNoTracking();
        }

        public async Task CreateAdAsync(Ad ad, CancellationToken cancellationToken)
        {
            await _context.Ads.AddAsync(ad, cancellationToken);
        }

        public async Task UpdateAdAsync(Ad ad, CancellationToken cancellationToken)
        {
            await _context.Ads.AddAsync(ad, cancellationToken);
        }

        public void DeleteAd(Ad ad)
        {
            _context.Ads.Remove(ad);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _context.Ads.CountAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new DatabaseTransaction(_context, isolationLevel);
        }
    }
}