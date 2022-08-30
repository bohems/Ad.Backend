using Application.Common.Mappings;
using Application.UseCases.Users.Queries.LoginUser;
using AutoMapper;

namespace WebApi.UseCases.V1.Auth.LoginUser
{
    public class LoginUserRequest : IMapWith<LoginUserQuery>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginUserRequest, LoginUserQuery>()
                .ForMember(loginQuery => loginQuery.Username,
                    opt => opt.MapFrom(loginRequest => loginRequest.Username))
                .ForMember(loginQuery => loginQuery.Password,
                    opt => opt.MapFrom(loginRequest => loginRequest.Password));
        }
    }
}
