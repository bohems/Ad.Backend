using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.UseCases.Ads.Commands.DeleteAd
{
    public class DeleteAdHandler 
        : IRequestHandler<DeleteAdCommand>
    {
        private readonly IAdRepository _repository;

        public DeleteAdHandler(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAdByIdAsync(request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            _repository.DeleteAd(entity);
            await _repository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
