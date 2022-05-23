
using AutoMapper;
using SGBenefic.API.Dtos;
using SGBenefic.API.Models;

namespace SGBenefic.API.Helpers
{
    public class SGBeneficProfile:Profile
    {
        public SGBeneficProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Beneficit, BeneficitDto>().ReverseMap();
        }
    }
}
