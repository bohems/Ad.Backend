using Application.Common.Sieve;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsHandler
        : IRequestHandler<GetAdvertisingsQuery, GetAdvertisingsCollection>
    {
        private readonly IAdvertisementsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public GetAdvertisingsHandler(IAdvertisementsDbContext dbContext,
            IMapper mapper, SieveProcessor sieveProcessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<GetAdvertisingsCollection> Handle(GetAdvertisingsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = _dbContext.Advertisings.AsNoTracking();

            var advertisingsElement = entity
                .ProjectTo<GetAdvertisingsElement>(_mapper.ConfigurationProvider);
                
            var pagedList = _sieveProcessor.Apply(request, advertisingsElement);

            var advertisingsCollection = new GetAdvertisingsCollection()
            {
                PagedList = pagedList
            };
                         
            return advertisingsCollection;
        }
    }
}
