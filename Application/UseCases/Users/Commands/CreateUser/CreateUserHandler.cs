using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using System.Security.Cryptography;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserHandler
        : IRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateUserHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Users.FirstOrDefault(user => user.Username == request.Username);

            if (entity is not null)
            {
                throw new AlreadyExistException(nameof(User), request.Username);
            }

            CreatePasswordHash(request.Password,
                out byte[] passwordHash, out byte[] passwordSalt);

            User user = new()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                IsAdmin = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }

        private void CreatePasswordHash(string password,
            out byte[] passwordHash, out byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
