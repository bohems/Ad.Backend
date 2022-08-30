using Application.Interfaces;
using Application.UseCases.Advertisings.Commands.CreateAdvertising;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Advertisings.Queries.GetAdvertising
{
    public class GetAdvertisingHandler 
        : IRequestHandler<GetAdvertisingQuery, GetAdvertisingResponse>
    {
        private readonly IAdvertisementsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAdvertisingHandler(IAdvertisementsDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAdvertisingResponse> Handle(GetAdvertisingQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Advertisings.
                FirstOrDefaultAsync(ad => ad.Id == request.Id, cancellationToken);

            return _mapper.Map<GetAdvertisingResponse>(entity); 
        }
    }
}
