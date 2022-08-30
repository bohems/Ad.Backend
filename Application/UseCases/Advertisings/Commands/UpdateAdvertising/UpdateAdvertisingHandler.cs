using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            entity.Text = request.Text;
            entity.ImageUrl = request.ImageUrl;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
