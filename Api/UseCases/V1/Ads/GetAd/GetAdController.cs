using Application.UseCases.Ads.Queries.GetAd;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Advertisings.GetAdvertising
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    sealed public class GetAdController : CustomControllerBase
    {
        /// <summary>
        /// Gets ad by id
        /// </summary>
        /// <returns>Returns <see cref="GetAdResponse" /></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAdResponse>> Get(Guid id)
        {
            GetAdQuery query = new()
            {
                Id = id
            };

            var adversting = await Mediator.Send(query);

            return Ok(adversting);
        }
    }
}
