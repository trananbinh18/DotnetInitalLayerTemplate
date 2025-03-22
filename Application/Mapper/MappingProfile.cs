using Application.Models.Responses;
using AutoMapper;
using Domain.Entities;

namespace BLogicDataCenter.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Post

            CreateMap<PostResponse, PostEntity>();
            
            #endregion
        }

    }
}
