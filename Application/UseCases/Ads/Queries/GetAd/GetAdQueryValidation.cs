using FluentValidation;

namespace Application.UseCases.Ads.Queries.GetAd
{
    public class GetAdQueryValidation : AbstractValidator<GetAdQuery>
    {
        public GetAdQueryValidation()
        {
            RuleFor(query =>
                query.Id).NotEqual(Guid.Empty);
        }
    }
}
