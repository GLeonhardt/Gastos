using AutoMapper;
using Gastos.Core.DTO;
using Gastos.Core.Models.DTO;
using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tags, TagsDTO>().ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.TagId));
            CreateMap<Movimentacoes, MovimentacoesInformacoesDTO>().ForMember(dest => dest.Tags,
                opt => opt.MapFrom(src => src.Tags.Select(x => x.Tag).ToList()));
            CreateMap<Detalhes, MovimentacoesDetalhesInformacoesDTO>().ForMember(dest => dest.Tags,
                opt => opt.MapFrom(source => source.Tags.Select(x => x.Tag)));
        }
    }
}
