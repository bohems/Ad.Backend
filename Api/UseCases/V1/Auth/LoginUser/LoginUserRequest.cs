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
                .ForMember(query => query.Username,
                    opt => opt.MapFrom(request => request.Username))
                .ForMember(query => query.Password,
                    opt => opt.MapFrom(request => request.Password));
        }
    }
}
