using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;

namespace Application.UseCases.Advertisings.Commands.UpdateAdvertising
{
    public class UpdateAdvertisingHandler : IRequestHandler<UpdateAdvertisingCommand>
    {
        private readonly IAdvertisementsDbContext _dbContext;

        public UpdateAdvertisingHandler(IAdvertisementsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateAdvertisingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Advertisings.
                FirstOrDefaultAsync(ad => ad.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Advertisings), request.Id);
            }

            if (entity.UserId != request.UserId)
            {
                throw new AccessDeniedException(nameof(Advertisings), request.Id.ToString());
            }

            entity.Text = request.Text;
            entity.ImageUrl = request.ImageUrl;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
