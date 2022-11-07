using Application.Common.Exceptions;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.UseCases.Ads.Queries.GetAd
{
    public class GetAdHandler 
        : IRequestHandler<GetAdQuery, GetAdResponse>
    {
        private readonly IAdRepository _repository;
        private readonly IMapper _mapper;

        public GetAdHandler(IAdRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAdResponse> Handle(GetAdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAdByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            return _mapper.Map<GetAdResponse>(entity); 
        }
    }
}
