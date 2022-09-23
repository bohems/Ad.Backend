using Application.Common.Mappings;
using Application.Common.Sieve;
using Application.UseCases.Ads.Queries.GetAds;
using AutoMapper;

namespace WebApi.UseCases.V1.Ads.GetAds
{
    public class GetAdsRequest : SieveModel, IMapWith<GetAdsQuery>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAdsRequest, GetAdsQuery>()

                .ForMember(query => query.Searching,
                    opt => opt.MapFrom(request => request.Searching))

                .ForMember(query => query.Filters,
                    opt => opt.MapFrom(request => request.Filters))

                .ForMember(query => query.SortProperty,
                    opt => opt.MapFrom(request => request.SortProperty))

                .ForMember(query => query.Page,
                    opt => opt.MapFrom(request => request.Page))

                .ForMember(query => query.PageSize,
                    opt => opt.MapFrom(request => request.PageSize));
        }
    }
}
