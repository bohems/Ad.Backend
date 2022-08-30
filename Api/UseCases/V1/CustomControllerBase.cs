using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.UseCases.V1
{
    abstract public class CustomControllerBase : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected Guid GetUserId() =>
            User.Identity.IsAuthenticated
                ? Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
                : Guid.Empty;
    }
}