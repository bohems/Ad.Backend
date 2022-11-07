using System.Data;

namespace Domain
{
    public interface IAdRepository
    {
        Task<Ad> GetAdByIdAsync(Guid id, CancellationToken cancellationToken);
        IQueryable<Ad> GetAllAds();
        Task CreateAdAsync(Ad ad, CancellationToken cancellationToken);
        Task UpdateAdAsync(Ad ad, CancellationToken cancellationToken);
        void DeleteAd(Ad ad);
        Task<int> CountAsync(CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}
