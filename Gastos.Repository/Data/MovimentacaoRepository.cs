using AutoMapper;
using Gastos.Core.DTO;
using Gastos.Core.Interfaces;
using Gastos.Core.Models.DTO;
using Gastos.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Infrastructure.Data
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private GastosContext _GastosContext;
        private IMapper _IMapper;
        public MovimentacaoRepository(GastosContext gastosContext, IMapper autoMapper)
        {
            _GastosContext = gastosContext;
            _IMapper = autoMapper;
        }


        public async Task<long> Create(Movimentacoes movimentacoes, List<long> tags)
        {
            var dbTags = _GastosContext.Tags.Where(x => tags.Contains(x.TagId)).ToList();
            foreach (var detalhe in movimentacoes.Detalhes)
            {
                detalhe.Tags = _GastosContext.Tags.Where(x => detalhe.Tags.Select(y => y.TagId).ToList().Contains(x.TagId)).ToList();
            }
            movimentacoes.Tags.AddRange(dbTags);
            _GastosContext.Movimentacoes.Add(movimentacoes);
            _ = await _GastosContext.SaveChangesAsync();
            return movimentacoes.MovimentacaoId;
        }

        public MovimentacoesInformacoesDTO GetMovimentacao(string userId, long movimentacaoId)
        {
            var movimentacao = _GastosContext.Movimentacoes
                    .Where(x => x.UsuarioId == userId && x.MovimentacaoId == movimentacaoId)
                    .Include(x => x.Detalhes).ThenInclude(x => x.Tags)
                    .Include(x => x.Tags)
                    .SingleOrDefault();

            return _IMapper.Map<MovimentacoesInformacoesDTO>(movimentacao);
        }

        public RelatorioMensallDTO GetRelatorioMovimentacoesMes(string userId, int mes, int ano)
        {
            var movimentacoes = _GastosContext.Movimentacoes
                .Where(x => x.UsuarioId == userId && x.Data.Month == mes && x.Data.Year == ano)
                .Include(x => x.TipoMovimentacao)
                .Include(x => x.Tags)
                .ToList();

            var retorno =  _IMapper.Map<RelatorioMensallDTO>(movimentacoes);
            retorno.Movimentacoes = _IMapper.Map<List<RelatorioMensalMovimentacoesDTO>>(movimentacoes);

            return retorno;
        }

        public ResumoHomeDTO GetResumoHome(string usuarioId, DateTime dataInicial, DateTime dataFinal, List<long> tags )
        {
            var movimentacoes = _GastosContext.Movimentacoes
                .Where(x => x.UsuarioId == usuarioId && x.Data >= dataInicial && x.Data <= dataFinal)
                .Include(x => x.Tags)
                .Include(x => x.Detalhes).ThenInclude(x => x.Tags)
                .ToList();

            if (tags != null && tags.Count > 0)
                movimentacoes = movimentacoes
                    .Where(
                        x => x.Tags.Select(y => y.TagId).Intersect(tags).Any() ||
                        x.Detalhes.Any(k => k.Tags.Select(z => z.TagId).Intersect(tags).Any())
                        ).ToList();

            return _IMapper.Map<ResumoHomeDTO>(movimentacoes);
        }

        public async Task<bool> ExcluirMovimentacao(string usuarioId, long movimentacaoId)
        {

            var movimentacao = _GastosContext.Movimentacoes.Where(x => x.UsuarioId == usuarioId && x.MovimentacaoId == movimentacaoId)
                .Include(x => x.Detalhes).ThenInclude(x => x.Tags)
                .Include(x => x.Tags)
                .FirstOrDefault();

            
            _GastosContext.Detalhes.RemoveRange(movimentacao.Detalhes);
            _GastosContext.Movimentacoes.Remove(movimentacao);

            var result = await _GastosContext.SaveChangesAsync();
            return true;
        }
    }
}
