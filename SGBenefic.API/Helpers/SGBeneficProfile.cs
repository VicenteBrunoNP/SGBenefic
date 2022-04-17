
using AutoMapper;
using SGBenefic.API.Dtos;
using SGBenefic.API.Models;

namespace SGBenefic.API.Helpers
{
    public class SGBeneficProfile:Profile
    {
        public SGBeneficProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.SobreNome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

        }
    }
}
