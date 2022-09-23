using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.UseCases.Ads.Commands.UpdateAd
{
    public class UpdateAdHandler : IRequestHandler<UpdateAdCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateAdHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Ads.
                FirstOrDefaultAsync(ad => ad.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            if (entity.UserId != request.UserId)
            {
                throw new AccessDeniedException(nameof(Ad), request.Id.ToString());
            }

            entity.Text = request.Text;
            entity.ImageUrl = request.ImageUrl;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
