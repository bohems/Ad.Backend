using Application.Common.Sieve;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;

namespace Application.UseCases.Ads.Queries.GetAds
{
    public class GetAdsHandler
        : IRequestHandler<GetAdsQuery, GetAdCollection>
    {
        private readonly IAdRepository _repository;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public GetAdsHandler(IAdRepository repository,
            IMapper mapper, SieveProcessor sieveProcessor)
        {
            _repository = repository;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<GetAdCollection> Handle(GetAdsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = _repository.GetAllAds();

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
