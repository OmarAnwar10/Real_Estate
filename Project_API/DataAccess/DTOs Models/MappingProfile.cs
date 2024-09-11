using AutoMapper;
using application.DataAccess.Models;
using Application.ServiceContracts;
using API_Project.DataAccess.Models;
using API_Project.DataAccess.DTOs_Models;


namespace API_Project.DataAccess.DTOs
{
  
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {



            CreateMap<Property, PropertyDto>()
    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
    .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.Amenities));



            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Inquiry, InquiryDto>();
            CreateMap<InquiryDto, Inquiry>();
            CreateMap<Favorite, FavoriteDto>();
            CreateMap<FavoriteDto, Favorite>();
            CreateMap<Amenities, AmenitiesDto>();
            CreateMap<AmenitiesDto, Amenities>();

            //CreateMap<User, UserWithOutIdDto>();
            //CreateMap<UserWithOutIdDto, User>();

            CreateMap<PropertywithAmenitiesDto, Property>()
    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
    .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => new Amenities
    {
        HasGarage = src.HasGarage,
        Two_Stories = src.Two_Stories,
        Laundry_Room = src.Laundry_Room,
        HasPool = src.HasPool,
        HasGarden = src.HasGarden,
        HasElevator = src.HasElevator,
        HasBalcony = src.HasBalcony,
        HasParking = src.HasParking,
        HasCentralHeating = src.HasCentralHeating,
        IsFurnished = src.IsFurnished,
        AdditionalNotes = src.AdditionalNotes
    }));

        }
    }

}
