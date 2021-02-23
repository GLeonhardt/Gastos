﻿using AutoMapper;
using Gastos.Core.DTO;
using Gastos.Core.Interfaces;
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


        public async Task<bool> Create(Movimentacoes movimentacoes, List<long> tags)
        {
            var dbTags = _GastosContext.Tags.Where(x => tags.Contains(x.TagId)).ToList();
            foreach (var detalhe in movimentacoes.Detalhes)
            {
                detalhe.Tags = _GastosContext.Tags.Where(x => detalhe.Tags.Select(y => y.TagId).ToList().Contains(x.TagId)).ToList();
            }
            movimentacoes.Tags.AddRange(dbTags);
            _GastosContext.Movimentacoes.Add(movimentacoes);
            _ = await _GastosContext.SaveChangesAsync();
            return true;
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
    }
}
