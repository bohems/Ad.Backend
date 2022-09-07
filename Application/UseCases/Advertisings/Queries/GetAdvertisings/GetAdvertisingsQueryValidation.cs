using FluentValidation;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsQueryValidation : AbstractValidator<GetAdvertisingsQuery>
    {
        public GetAdvertisingsQueryValidation() { }
    }
}
