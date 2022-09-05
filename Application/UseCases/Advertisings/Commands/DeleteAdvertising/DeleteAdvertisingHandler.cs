using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.UseCases.Advertisings.Commands.DeleteAdvertising
{
    public class DeleteAdvertisingHandler 
        : IRequestHandler<DeleteAdvertisingCommand>
    {
        private readonly IAdvertisementsDbContext _dbContext;

        public DeleteAdvertisingHandler(IAdvertisementsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteAdvertisingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Advertisings
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Advertising), request.Id);
            }

            if (entity.UserId != request.UserId)
            {
                throw new AccessDeniedException(nameof(Advertising), request.Id.ToString());
            }

            _dbContext.Advertisings.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);            

            return Unit.Value;
        }
    }
}
