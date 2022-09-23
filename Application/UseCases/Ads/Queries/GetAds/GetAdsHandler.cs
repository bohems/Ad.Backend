using Application.Common.Sieve;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Ads.Queries.GetAds
{
    public class GetAdsHandler
        : IRequestHandler<GetAdsQuery, GetAdCollection>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public GetAdsHandler(IApplicationDbContext dbContext,
            IMapper mapper, SieveProcessor sieveProcessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<GetAdCollection> Handle(GetAdsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = _dbContext.Ads.AsNoTracking();

            var adElement = entity
                .ProjectTo<GetAdElement>(_mapper.ConfigurationProvider);
                
            var pagedList = _sieveProcessor.Apply(request, adElement);

            var adCollection = new GetAdCollection()
            {
                PagedList = pagedList
            };
                         
            return adCollection;
        }
    }
}
