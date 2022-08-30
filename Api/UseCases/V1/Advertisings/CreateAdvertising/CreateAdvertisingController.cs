using Application.UseCases.Advertisings.Commands.CreateAdvertising;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Advertisings.CreateAdvertising
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CreateAdvertisingController : CustomControllerBase
    {
        private IMapper _mapper;

        public CreateAdvertisingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Сreates a new advertising
        /// </summary>
        /// <returns>Returns <see cref="Guid" /></returns>
        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAdvertisingRequest createRequest)
        {
            var command = _mapper.Map<CreateAdvertisingCommand>(createRequest);

            command.UserId = GetUserId();

            var advertisingId = await Mediator.Send(command);

            return Ok(advertisingId);
        }
    }
}
