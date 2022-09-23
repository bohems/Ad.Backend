using Application.Common.Mappings;
using Application.UseCases.Ads.Commands.CreateAd;
using AutoMapper;

namespace WebApi.UseCases.V1.Ads.CreateAd
{
    public class CreateAdRequest : IMapWith<CreateAdCommand>
    {
        public string Text { get; set; }
        public string? ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAdRequest, CreateAdCommand>()
                .ForMember(command => command.Text,
                    opt => opt.MapFrom(request => request.Text))
                .ForMember(command => command.ImageUrl,
                    opt => opt.MapFrom(request => request.ImageUrl));
        }
    }
}
 