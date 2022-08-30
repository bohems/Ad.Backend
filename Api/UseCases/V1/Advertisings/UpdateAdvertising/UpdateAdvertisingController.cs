using Application.UseCases.Advertisings.Commands.UpdateAdvertising;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Advertisings.UpdateAdvertising
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class UpdateAdvertisingController : CustomControllerBase
    {
        private IMapper _mapper;

        public UpdateAdvertisingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Updates an existing advertising
        /// </summary>
        /// <returns>Returns <see cref="ActionResult" /></returns>
        [Authorize]
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateAdvertisingRequest updateRequest)
        {
            var command = _mapper.Map<UpdateAdvertisingCommand>(updateRequest);

            await Mediator.Send(command);

            return Accepted();
        }
    }
}
