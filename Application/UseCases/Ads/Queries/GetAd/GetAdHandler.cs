using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Ads.Queries.GetAd
{
    public class GetAdHandler 
        : IRequestHandler<GetAdQuery, GetAdResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAdHandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAdResponse> Handle(GetAdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Ads.
                FirstOrDefaultAsync(ad => ad.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            return _mapper.Map<GetAdResponse>(entity); 
        }
    }
}
