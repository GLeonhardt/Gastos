using AutoMapper;
using Gastos.Core.DTO;
using Gastos.Core.Models.DTO;
using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Gastos.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tags, TagsDTO>()
                .ForMember(destination => destination.Id,
                    opt => opt.MapFrom(source => source.TagId));

            CreateMap<Movimentacoes, MovimentacoesInformacoesDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.MovimentacaoId))
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => src.Tags.Select(x => x.Tag).ToList()));

            CreateMap<Detalhes, MovimentacoesDetalhesInformacoesDTO>()
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(source => source.Tags.Select(x => x.Tag)));

            CreateMap<Movimentacoes, RelatorioMensalMovimentacoesDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MovimentacaoId))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => Math.Round(src.Valor)))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.TipoMovimentacao.Tipo))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Tag)));

            CreateMap<List<Movimentacoes>, RelatorioMensallDTO>()
                .ForMember(dest => dest.Periodo, opt => opt.MapFrom(src => src.FirstOrDefault().Data.ToString("MMMM - yyyy")))
                .ForMember(dest => dest.Quantidade, opt =>
                    opt.MapFrom(src => src.Count()))
                .ForMember(dest => dest.Entrada,
                    opt => opt.MapFrom(src => Math.Round(src.Where(x => x.TipoMovimentacaoId == 1).Sum(x => x.Valor), 2)))
                .ForMember(dest => dest.Saida, opt =>
                    opt.MapFrom(src => Math.Round(src.Where(x => x.TipoMovimentacaoId == 2).Sum(x => x.Valor), 2)))
                .AfterMap((src, dest) => dest.Saldo = dest.Entrada - dest.Saida);

            CreateMap<List<Movimentacoes>, ResumoHomeDTO>()
             .ForMember(dest => dest.Entradas,
                 opt => opt.MapFrom(src => Math.Round(src.Where(x => x.TipoMovimentacaoId == 1).Sum(x => x.Valor), 2)))
             .ForMember(dest => dest.Saidas, opt =>
                 opt.MapFrom(src => Math.Round(src.Where(x => x.TipoMovimentacaoId == 2).Sum(x => x.Valor), 2)))
             .ForMember(x => x.Mensal, opt => opt.MapFrom(src => src.GroupBy(y => y.Data.Month).Select(
                 z => new ResumoHomeMesDTO
                 {
                     Mes = z.First().Data,
                     Entradas = Math.Round(z.Where(x => x.TipoMovimentacaoId == 1).Sum(x => x.Valor),2),
                     Saidas = Math.Round(z.Where(x => x.TipoMovimentacaoId == 2).Sum(x => x.Valor),2),
                     QuantidadeMovimentacoes = z.ToList().Count,
                     Saldo = Math.Round(z.Where(x => x.TipoMovimentacaoId == 1).Sum(x => x.Valor), 2) - Math.Round(z.Where(x => x.TipoMovimentacaoId == 2).Sum(x => x.Valor), 2)
                 }
                )))
            .AfterMap((src, dest) => dest.Saldo = dest.Entradas - dest.Saidas);
        }
    }
}
