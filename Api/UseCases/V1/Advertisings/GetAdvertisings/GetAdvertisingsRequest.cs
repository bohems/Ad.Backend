using Application.Common.Mappings;
using Application.Common.Sieve;
using Application.UseCases.Advertisings.Queries.GetAdvertisings;
using AutoMapper;

namespace WebApi.UseCases.V1.Advertisings.GetAdvertisings
{
    public class GetAdvertisingsRequest : SieveModel, IMapWith<GetAdvertisingsQuery>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAdvertisingsRequest, GetAdvertisingsQuery>()

                .ForMember(getQuery => getQuery.Searching,
                    opt => opt.MapFrom(getRequest => getRequest.Searching))

                .ForMember(getQuery => getQuery.Filters,
                    opt => opt.MapFrom(getRequest => getRequest.Filters))

                .ForMember(getQuery => getQuery.SortProperty,
                    opt => opt.MapFrom(getRequest => getRequest.SortProperty))

                .ForMember(getQuery => getQuery.Page,
                    opt => opt.MapFrom(getRequest => getRequest.Page))

                .ForMember(getQuery => getQuery.PageSize,
                    opt => opt.MapFrom(getRequest => getRequest.PageSize));
        }
    }
}
