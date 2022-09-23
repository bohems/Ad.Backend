using Application.UseCases.Ads.Commands.CreateAd;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Ads.CreateAd
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CreateAdController : CustomControllerBase
    {
        private IMapper _mapper;

        public CreateAdController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Сreates a new ad
        /// </summary>
        /// <returns>Returns <see cref="Guid" /></returns>
        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAdRequest createRequest)
        {
            var command = _mapper.Map<CreateAdCommand>(createRequest);

            command.UserId = GetUserId();

            var adId = await Mediator.Send(command);

            return Ok(adId);
        }
    }
}
