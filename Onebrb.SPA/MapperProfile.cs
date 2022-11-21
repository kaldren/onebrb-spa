using Onebrb.SPA.Models;
using OnebrbApi;

namespace Onebrb.SPA
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            #region Profile
            CreateMap<UserProfileResponseModel, UserProfileModel>()
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone ?? string.Empty))
            .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.About ?? string.Empty))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country ?? string.Empty))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City ?? string.Empty))
            .ForMember(dest => dest.LinkedInProfile, opt => opt.MapFrom(src => src.LinkedInProfile ?? string.Empty))
            .ForMember(dest => dest.FacebookProfile, opt => opt.MapFrom(src => src.FacebookProfile ?? string.Empty))
            .ForMember(dest => dest.InstagramProfile, opt => opt.MapFrom(src => src.InstagramProfile ?? string.Empty))
            .ForMember(dest => dest.OccupationName, opt => opt.MapFrom(src => src.OccupationName ?? string.Empty));

            CreateMap<UserProfileModel, UpdateUserProfileRequestModel>();
            #endregion Profile

            #region Comment
            CreateMap<CommentResponseModel, CommentModel>()
                .ForMember(
                    dest => dest.DateCreated,
                    opt => opt.MapFrom(src => src.DateCreated)
                );
            #endregion Comment

            #region Occupation
            CreateMap<OccupationResponseModel, OccupationModel>();
            #endregion Occupation
        }
    }
}
