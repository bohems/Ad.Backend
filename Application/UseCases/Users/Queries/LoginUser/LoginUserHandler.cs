using Application.Common;
using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Application.UseCases.Users.Queries.LoginUser
{
    public class LoginUserHandler
        : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly JwtSettingsOptions _options;

        public LoginUserHandler(IUserRepository repository, IConfiguration configuration, IOptions<JwtSettingsOptions> options)
        {
            _repository = repository;
            _configuration = configuration;
            _options = options.Value;
        }

        public async Task<string> Handle(LoginUserQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.GetUserByUsernameAsync(request.Username,
                cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(User), request.Username);
            }

            if (VerifyPasswordHash(request.Password, entity.PasswordHash, entity.PasswordSalt)
                is not true)
            {
                throw new WrongPasswordException();
            }

            string token = CreateToken(entity.Id, entity.Username);

            return token;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new(passwordSalt);

            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }

        private string CreateToken(Guid id, string username)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "User")
            };

            SymmetricSecurityKey key = new(System.Text.Encoding.UTF8.GetBytes(_options.Secret));

            JwtSecurityToken token = new(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new(key, SecurityAlgorithms.HmacSha512Signature)
            );

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
