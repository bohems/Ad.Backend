using Application.UseCases.Advertisings.Queries.GetAdvertising;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Advertisings.GetAdvertising
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    sealed public class GetAdvertisingController : CustomControllerBase
    {
        /// <summary>
        /// Gets advertising by id
        /// </summary>
        /// <returns>Returns <see cref="GetAdvertisingResponse" /></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAdvertisingResponse>> Get(Guid id)
        {
            GetAdvertisingQuery query = new()
            {
                Id = id
            };

            var adversting = await Mediator.Send(query);

            return Ok(adversting);
        }
    }
}
