namespace Domain
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username, CancellationToken cancellationToken);
        Task AddUserAsync(User user, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
