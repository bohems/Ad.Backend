using Application.UseCases.Ads.Queries.GetAds;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Ads.GetAds
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class GetAdsController : CustomControllerBase
    {
        private IMapper _mapper;

        public GetAdsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Gets list of ad with the given parameters
        /// </summary>
        /// <returns>Returns <see cref="GetAdCollection" /></returns>

        [HttpGet("GetAll")]
        public async Task<ActionResult<GetAdCollection>> 
            GetAdvertisings([FromQuery] GetAdsRequest request)
        {
            var query = _mapper.Map<GetAdsQuery>(request);

            var ads = await Mediator.Send(query);

            return Ok(ads);
        }
    }
}
