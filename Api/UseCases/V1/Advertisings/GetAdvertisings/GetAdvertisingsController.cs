using Application.UseCases.Advertisings.Queries.GetAdvertisings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Advertisings.GetAdvertisings
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class GetAdvertisingsController : CustomControllerBase
    {
        private IMapper _mapper;

        public GetAdvertisingsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Gets list of advertisings with the given parameters
        /// </summary>
        /// <returns>Returns <see cref="GetAdvertisingsCollection" /></returns>

        [HttpGet("GetAll")]
        public async Task<ActionResult<GetAdvertisingsCollection>> 
            GetAdvertisings([FromQuery] GetAdvertisingsRequest request)
        {
            var query = _mapper.Map<GetAdvertisingsQuery>(request);

            var advertisings = await Mediator.Send(query);

            return Ok(advertisings);
        }
    }
}
