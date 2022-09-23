using Application.Common.Mappings;
using Application.UseCases.Ads.Commands.UpdateAd;
using AutoMapper;

namespace WebApi.UseCases.V1.Ads.UpdateAd
{
    public class UpdateAdRequest : IMapWith<UpdateAdCommand>
    {
        public Guid Id { get; set; }        
        public string Text { get; set; }
        public string? ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAdRequest, UpdateAdCommand>()
                .ForMember(command => command.Id,
                    opt => opt.MapFrom(request => request.Id))
                .ForMember(command => command.Text,
                    opt => opt.MapFrom(request => request.Text))
                .ForMember(command => command.ImageUrl,
                    opt => opt.MapFrom(request => request.ImageUrl));
        }
    }
}
