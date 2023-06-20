using Api.Domain.Entity;
using Api.Domain.Model;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<InsertUserModel,UserEntity>().ReverseMap();
            CreateMap<UpdateUserModel,UserEntity>().ReverseMap();
            CreateMap<UserModel,UserEntity>().ReverseMap();
        }
    }
}
