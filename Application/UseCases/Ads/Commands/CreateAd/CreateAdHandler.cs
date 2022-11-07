using Application.Common;
using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.Extensions.Options;
using System.Data;

namespace Application.UseCases.Ads.Commands.CreateAd
{
    public class CreateAdHandler
        : IRequestHandler<CreateAdCommand, Guid>
    {
        private readonly IAdRepository _repository;
        private readonly UserOptions _userOptions;

        public CreateAdHandler(IAdRepository adRepository, IOptions<UserOptions> options)
        {
            _repository = adRepository;
            _userOptions = options.Value;

        }

        public async Task<Guid> Handle(CreateAdCommand request,
            CancellationToken cancellationToken)
        {
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

            using var transaction = _repository.BeginTransaction(IsolationLevel.ReadUncommitted);

            await _repository.CreateAdAsync(ad, cancellationToken);

            await _repository.SaveAsync(cancellationToken);

            var count = await _repository.CountAsync(cancellationToken);

            if (count > _userOptions.MaxAdsCount)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new LimitExceededException(nameof(Ad), ad.UserId.ToString());
            }

            else await transaction.CommitAsync(cancellationToken);

            return ad.Id;
        }
    }
}
