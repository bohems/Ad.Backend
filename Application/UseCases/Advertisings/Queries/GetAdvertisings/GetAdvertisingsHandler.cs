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

            var paginedList = _sieveProcessor.Apply(request, entity);

            entity = paginedList.Items;

            var result = entity
                .ProjectTo<GetAdvertisingsElement>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken).Result;

            return new GetAdvertisingsCollection
            {
                Advertisings = result,
                CurrentPage = paginedList.CurrentPage,
                PageSize = paginedList.PageSize,
                TotalCount = paginedList.TotalCount
            };
        }
    }
}
