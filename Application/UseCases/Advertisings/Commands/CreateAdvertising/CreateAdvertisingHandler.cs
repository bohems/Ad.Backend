using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.UseCases.Advertisings.Commands.CreateAdvertising
{
    public class CreateAdvertisingHandler
        : IRequestHandler<CreateAdvertisingCommand, Guid>
    {
        private readonly IAdvertisementsDbContext _dbContext;

        public CreateAdvertisingHandler(IAdvertisementsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateAdvertisingCommand request, 
            CancellationToken cancellationToken)
        {
            Advertising advertising = new()
            {
                Id = Guid.NewGuid(),
                Number = 0,
                Text = request.Text,
                ImageUrl = request.ImageUrl,
                Rating = 0,
                CreationDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(1),
                UserId = request.UserId
            };

            await _dbContext.Advertisings.AddAsync(advertising, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return advertising.Id;
        }
    }
}
