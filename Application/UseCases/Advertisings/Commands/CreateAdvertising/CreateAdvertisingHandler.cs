using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Application.Common.Exceptions;

namespace Application.UseCases.Advertisings.Commands.CreateAdvertising
{
    public class CreateAdvertisingHandler
        : IRequestHandler<CreateAdvertisingCommand, Guid>
    {
        private readonly IAdvertisementsDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CreateAdvertisingHandler(IAdvertisementsDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Guid> Handle(CreateAdvertisingCommand request, 
            CancellationToken cancellationToken)
        {
            var userAdCount = _dbContext.Advertisings.Where(ad => ad.UserId == request.UserId).Count();

            var maxAdCount = int.Parse(_configuration["MaxAdCount"]);

            if (userAdCount > maxAdCount)
            {
                throw new LimitExceededException(nameof(Advertising), request.UserId.ToString());
            }

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
