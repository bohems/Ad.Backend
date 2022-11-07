using Application.Common.Exceptions;
using Domain;
using MediatR;
using System.Security.Cryptography;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserHandler
        : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _userRepository.GetUserByUsernameAsync(request.Username,
                cancellationToken);

            if (entity.Result is not null)
            {
                throw new AlreadyExistException(nameof(User), request.Username);
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                IsAdmin = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _userRepository.AddUserAsync(user, cancellationToken);
            await _userRepository.SaveAsync(cancellationToken);

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
