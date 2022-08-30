using MediatR;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsQuery : IRequest<GetAdvertisingsCollection>
    {
        public Guid UserId { get; set; }
    }
}
