using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Application.Common.Exceptions;

namespace Application.UseCases.Ads.Commands.CreateAd
{
    public class CreateAdHandler
        : IRequestHandler<CreateAdCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CreateAdHandler(IApplicationDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Guid> Handle(CreateAdCommand request, 
            CancellationToken cancellationToken)
        {
            var userAdCount = _dbContext.Ads.Where(ad => ad.UserId == request.UserId).Count();

            var maxAdCount = int.Parse(_configuration["MaxAdCount"]);

            if (userAdCount > maxAdCount)
            {
                throw new LimitExceededException(nameof(Ad), request.UserId.ToString());
            }

            Ad ad = new()
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

            await _dbContext.Ads.AddAsync(ad, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ad.Id;
        }
    }
}
