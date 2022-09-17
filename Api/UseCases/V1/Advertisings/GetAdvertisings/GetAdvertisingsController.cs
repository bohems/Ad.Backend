using Application.UseCases.Advertisings.Queries.GetAdvertisings;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Advertisings.GetAllAdvertising
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class GetAdvertisingsController : CustomControllerBase
    {
        /// <summary>
        /// Gets list of advertisings with the given parameters
        /// </summary>
        /// <returns>Returns <see cref="GetAdvertisingsCollection" /></returns>

        [HttpGet("GetAll")]
        public async Task<ActionResult<GetAdvertisingsCollection>> GetAdvertisings()
        {
            GetAdvertisingsQuery query = new();
            var advertisings = await Mediator.Send(query);

            return Ok(advertisings);
        }
    }
}
