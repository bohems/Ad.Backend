using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.UseCases.Ads.Queries.GetAds
{
    public class GetAdElement : IMapWith<Ad>
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
            profile.CreateMap<Ad, GetAdElement>()
                .ForMember(element => element.Id,
                    opt => opt.MapFrom(ad => ad.Id))

                .ForMember(element => element.Number,
                    opt => opt.MapFrom(ad => ad.Number))

                .ForMember(element => element.Text,
                    opt => opt.MapFrom(ad => ad.Text))

                .ForMember(element => element.ImageUrl,
                    opt => opt.MapFrom(ad => ad.ImageUrl))

                .ForMember(element => element.Rating,
                    opt => opt.MapFrom(ad => ad.Rating))

                .ForMember(element => element.CreationDate,
                    opt => opt.MapFrom(ad => ad.CreationDate))

                .ForMember(element => element.ExpiryDate,
                    opt => opt.MapFrom(ad => ad.ExpiryDate));
        }
    }
}
