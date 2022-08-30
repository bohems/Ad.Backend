using Application.UseCases.Users.Queries.LoginUser;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Auth.LoginUser
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class LoginUserController : CustomControllerBase
    {
        private readonly IMapper _mapper;

        public LoginUserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Login procedure for User
        /// </summary>
        /// <returns>Returns <see cref="string" /></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginUserRequest loginRequest)
        {
            var query = _mapper.Map<LoginUserQuery>(loginRequest);

            string jwt = await Mediator.Send(query);

            return jwt;
        }

    }
}
