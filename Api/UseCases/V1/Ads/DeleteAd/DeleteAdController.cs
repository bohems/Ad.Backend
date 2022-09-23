using Application.UseCases.Ads.Commands.DeleteAd;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Ads.DeleteAd
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class DeleteAdController : CustomControllerBase
    {
        /// <summary>
        /// Delete ad by id
        /// </summary>
        /// <returns>Returns <see cref="ActionResult" /></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            DeleteAdCommand command = new() { Id = id, UserId = GetUserId() };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
