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
            #endregion Profile

            #region Comment
            CreateMap<CommentResponseModel, CommentModel>();
            #endregion Comment

            #region Product
            CreateMap<ProductResponseModel, ProductModel>();
            CreateMap<ProductImageResponseModel, ProductImageModel>();
            #endregion Product
        }
    }
}
