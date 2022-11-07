using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username,
            CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Username == username,
                cancellationToken);
        }

        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            _context.SaveChanges();
        }
    }
}
