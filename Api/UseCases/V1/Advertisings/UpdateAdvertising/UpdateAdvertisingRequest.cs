using Application.Common.Mappings;
using Application.UseCases.Advertisings.Commands.UpdateAdvertising;
using AutoMapper;

namespace WebApi.UseCases.V1.Advertisings.UpdateAdvertising
{
    public class UpdateAdvertisingRequest : IMapWith<UpdateAdvertisingCommand>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string? ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAdvertisingRequest, UpdateAdvertisingCommand>()
                .ForMember(updateCommand => updateCommand.Id,
                    opt => opt.MapFrom(updateRequest => updateRequest.Id))
                .ForMember(updateCommand => updateCommand.Text,
                    opt => opt.MapFrom(updateRequest => updateRequest.Text))
                .ForMember(updateCommand => updateCommand.ImageUrl,
                    opt => opt.MapFrom(updateRequest => updateRequest.ImageUrl));


        }
    }
}
