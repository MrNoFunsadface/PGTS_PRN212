using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User DTOs
            CreateMap<User, UserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserResetPasswordDTO>().ReverseMap();
            CreateMap<User, UserProfileDTO>().ReverseMap();

            // Pregnancy DTOs
            CreateMap<Pregnancy, PregnancyRequestDTO>().ReverseMap();
            CreateMap<Pregnancy, PregnancyResponseDTO>().ReverseMap();
        }
    }
}
