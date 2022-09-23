using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.UseCases.Ads.Queries.GetAd
{
    public class GetAdResponse : IMapWith<Ad>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public string? ImageUrl { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ad, GetAdResponse>()
                .ForMember(response => response.Id,
                    opt => opt.MapFrom(ad => ad.Id))

                .ForMember(response => response.Number,
                    opt => opt.MapFrom(ad => ad.Number))

                .ForMember(response => response.Text,
                    opt => opt.MapFrom(ad => ad.Text))

                .ForMember(response => response.ImageUrl,
                    opt => opt.MapFrom(ad => ad.ImageUrl))

                .ForMember(response => response.Rating,
                    opt => opt.MapFrom(ad => ad.Rating))

                .ForMember(response => response.CreationDate,
                    opt => opt.MapFrom(ad => ad.CreationDate))

                .ForMember(response => response.ExpiryDate,
                    opt => opt.MapFrom(ad => ad.ExpiryDate));

        }
    }
}
