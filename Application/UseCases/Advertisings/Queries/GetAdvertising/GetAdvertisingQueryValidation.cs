using FluentValidation;

namespace Application.UseCases.Advertisings.Queries.GetAdvertising
{
    public class GetAdvertisingQueryValidation : AbstractValidator<GetAdvertisingQuery>
    {
        public GetAdvertisingQueryValidation()
        {
            RuleFor(getAdvertisingQueryValidation =>
                getAdvertisingQueryValidation.Id).NotEqual(Guid.Empty);
        }
    }
}
