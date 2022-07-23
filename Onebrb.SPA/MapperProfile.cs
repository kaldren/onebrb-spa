using Onebrb.SPA.Models;
using OnebrbApi;

namespace Onebrb.SPA
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            #region Profile
            CreateMap<UserProfileResponseModel, UserProfileModel>();
            CreateMap<UserProfileModel, UpdateUserProfileRequestModel>();
            #endregion

            #region Comment
            CreateMap<CommentResponseModel, CommentModel>();
            #endregion
        }
    }
}
