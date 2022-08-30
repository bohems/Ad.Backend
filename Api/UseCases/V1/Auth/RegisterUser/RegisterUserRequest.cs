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
                .ForMember(registerCommand => registerCommand.Username,
                    opt => opt.MapFrom(registerRequest => registerRequest.Username))
                .ForMember(registerCommand => registerCommand.Password,
                    opt => opt.MapFrom(registerRequest => registerRequest.Password));
        }
    }
}
