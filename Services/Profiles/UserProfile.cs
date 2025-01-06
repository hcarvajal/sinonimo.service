using AutoMapper;
using Domain.Entities;
using Models;
using Models.UserDTO;


namespace Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserForCreateDTO, User>();
            CreateMap<UserForUpdateDTO, User>();
            CreateMap<User,UserForUpdateDTO>();
        }
    }
}
