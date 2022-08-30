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

        public GetAdvertisingsHandler(IAdvertisementsDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAdvertisingsCollection> Handle(GetAdvertisingsQuery request, 
            CancellationToken cancellationToken)
        {
            var entity = _dbContext.Advertisings
                .Where(ad => ad.UserId == request.UserId)
                .ProjectTo<GetAdvertisingsElement>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken).Result;

            return new GetAdvertisingsCollection { Advertisings = entity } ;
        }
    }
}
