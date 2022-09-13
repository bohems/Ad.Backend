using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsHandler 
        : IRequestHandler<GetAdvertisingsQuery, GetAdvertisingsCollection>
    {
        private readonly IAdvertisementsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _processor;

        public GetAdvertisingsHandler(IAdvertisementsDbContext dbContext,
            IMapper mapper, SieveProcessor processor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _processor = processor;
        }

        public async Task<GetAdvertisingsCollection> Handle(GetAdvertisingsQuery request, 
            CancellationToken cancellationToken)
        {
            var entity = _dbContext.Advertisings.AsNoTracking();

            entity = _processor.Apply(request.SieveModel, entity);

            var result = entity
                .ProjectTo<GetAdvertisingsElement>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken).Result;

            return new GetAdvertisingsCollection { Advertisings = result };
        }
    }
}
