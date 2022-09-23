using Application.Common.Mappings;
using Application.UseCases.Users.Commands.CreateUser;
using AutoMapper;

namespace WebApi.UseCases.V1.Auth.RegisterUser
{
    public class RegisterUserRequest : IMapWith<CreateUserCommand>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterUserRequest, CreateUserCommand>()
                .ForMember(command => command.Username,
                    opt => opt.MapFrom(request => request.Username))
                .ForMember(command => command.Password,
                    opt => opt.MapFrom(request => request.Password));
        }
    }
}
