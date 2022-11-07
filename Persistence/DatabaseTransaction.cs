using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Persistence
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public DatabaseTransaction(AppDbContext context, IsolationLevel isolationLevel) 
        {
            _transaction = context.Database.BeginTransaction(isolationLevel);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _transaction.CommitAsync();
        }
                
        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction.Dispose(); 
        }
    }
}
