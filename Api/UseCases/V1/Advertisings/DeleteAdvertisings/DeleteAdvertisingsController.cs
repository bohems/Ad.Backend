using Application.UseCases.Advertisings.Commands.DeleteAdvertising;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.V1.Advertisings.DeleteAdvertisings
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class DeleteAdvertisingsController : CustomControllerBase
    {
        /// <summary>
        /// Delete advertising by id
        /// </summary>
        /// <returns>Returns <see cref="ActionResult" /></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            DeleteAdvertisingCommand command = new() { Id = id, UserId = GetUserId() };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
