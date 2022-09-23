using Application.UseCases.Ads.Commands.UpdateAd;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Ads.UpdateAd
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class UpdateAdController : CustomControllerBase
    {
        private IMapper _mapper;

        public UpdateAdController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Updates an existing ad
        /// </summary>
        /// <returns>Returns <see cref="ActionResult" /></returns>
        [Authorize]
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateAdRequest updateRequest)
        {
            var command = _mapper.Map<UpdateAdCommand>(updateRequest);
            command.UserId = GetUserId();

            await Mediator.Send(command);

            return Accepted();
        }
    }
}
