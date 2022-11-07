using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.UseCases.Ads.Commands.UpdateAd
{
    public class UpdateAdHandler : IRequestHandler<UpdateAdCommand>
    {
        private readonly IAdRepository _repository;
        public UpdateAdHandler(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAdByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            if (entity.UserId != request.UserId)
            {
                throw new AccessDeniedException(nameof(Ad), request.Id.ToString());
            }

            await _repository.UpdateAdAsync(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
