using Application.UseCases.Users.Commands.CreateUser;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Auth.RegisterUser
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class RegisterUserController : CustomControllerBase
    {
        private readonly IMapper _mapper;

        public RegisterUserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <returns>Returns <see cref="ActionResult" /></returns>
        [HttpPost("Register")]
        public async Task<ActionResult> Register(
            [FromBody] RegisterUserRequest registerUserRequest)
        {
            var command = _mapper.Map<CreateUserCommand>(registerUserRequest);

            await Mediator.Send(command);

            return Ok();
        }
    }
}
