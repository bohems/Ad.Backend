using Application.UseCases.Advertisings.Queries.GetAdvertisings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<GetAdvertisingsCollection>> GetAll()
        {
            GetAdvertisingsQuery query = new();
            var advertisings = await Mediator.Send(query);

            return Ok(advertisings);
        }
    }
}
