using Application.Common.Mappings;
using Application.UseCases.Advertisings.Commands.CreateAdvertising;
using AutoMapper;

namespace WebApi.UseCases.V1.Advertisings.CreateAdvertising
{
    public class CreateAdvertisingRequest : IMapWith<CreateAdvertisingCommand>
    {
        public string Text { get; set; }
        public string? ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAdvertisingRequest, CreateAdvertisingCommand>()
                .ForMember(createCommand => createCommand.Text,
                    opt => opt.MapFrom(createRequest => createRequest.Text))
                .ForMember(createCommand => createCommand.ImageUrl,
                    opt => opt.MapFrom(createRequest => createRequest.ImageUrl));
        }

    }
}
