using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.UseCases.Ads.Commands.DeleteAd
{
    public class DeleteAdHandler 
        : IRequestHandler<DeleteAdCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteAdHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Ads
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            if (entity.UserId != request.UserId)
            {
                throw new AccessDeniedException(nameof(Ad), request.Id.ToString());
            }

            _dbContext.Ads.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);            

            return Unit.Value;
        }
    }
}
