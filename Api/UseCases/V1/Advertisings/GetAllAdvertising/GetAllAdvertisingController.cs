using Application.UseCases.Advertisings.Queries.GetAdvertisings;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace WebApi.UseCases.V1.Advertisings.GetAllAdvertising
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class GetAllAdvertisingController : CustomControllerBase
    {
        /// <summary>
        /// Gets list of advertisings
        /// </summary>
        /// <returns>Returns <see cref="GetAdvertisingsCollection" /></returns>

        [HttpGet("GetAll")]
        public async Task<ActionResult<GetAdvertisingsCollection>> GetAll(
            [FromQuery] SieveModel sieveModel)
        {
            GetAdvertisingsQuery query = new() { SieveModel = sieveModel };
            var advertisings = await Mediator.Send(query);

            return Ok(advertisings);
        }
    }
}
