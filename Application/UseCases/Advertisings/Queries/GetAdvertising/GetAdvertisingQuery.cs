using Application.UseCases.Advertisings.Commands.CreateAdvertising;
using MediatR;

namespace Application.UseCases.Advertisings.Queries.GetAdvertising
{
    public class GetAdvertisingQuery : IRequest<GetAdvertisingResponse>
    {
        public Guid Id { get; set; }
    }
}
