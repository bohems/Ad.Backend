using FluentValidation;

namespace Application.UseCases.Ads.Queries.GetAds
{
    public class GetAdsQueryValidation : AbstractValidator<GetAdsQuery>
    {
        public GetAdsQueryValidation() { }
    }
}
