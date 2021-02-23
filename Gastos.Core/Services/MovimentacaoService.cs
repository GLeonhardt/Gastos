using Gastos.Core.DTO;
using Gastos.Core.Interfaces;
using Gastos.Core.Models;
using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Core.Services
{
    public class MovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private TagsService _tagsService;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository, TagsService tagsService)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _tagsService = tagsService;
        }

        public async Task<bool> Create(MovimentacaoPost movimentacaoPost, string usuarioId)
        {
            movimentacaoPost.Data = movimentacaoPost.Data == null ? DateTime.Now : movimentacaoPost.Data;
            var tags = await _tagsService.GetTagsByUsuario(usuarioId);
            var tagList = tags.Where(x => movimentacaoPost.Tags.Contains(x.Id))
                    .Select(x => x.Id).ToList();

            var detalhes = new List<Detalhes>();

            foreach(var detalhe in movimentacaoPost.Detalhes)
            {
                detalhes.Add(new Detalhes()
                {
                    Nome = detalhe.Detalhe,
                    Valor = detalhe.Valor,
                    Tags = tags.Where(x => detalhe.Tags.Contains(x.Id)).Select(x => new Tags { TagId = x.Id }).ToList()
                });
            }
            var movimentacao = new Movimentacoes
            {
                TipoMovimentacaoId = (long)movimentacaoPost.TipoMovimentacao,
                Data = Convert.ToDateTime(movimentacaoPost.Data),
                Nome = movimentacaoPost.Nome,
                Valor = movimentacaoPost.Valor,
                UsuarioId = usuarioId,
                Detalhes = detalhes
            };
            return await _movimentacaoRepository.Create(movimentacao, tagList);
        }
        public MovimentacoesInformacoesDTO GetMovimentacao(string userId, long movimentacaoId)
        {
            return _movimentacaoRepository.GetMovimentacao(userId, movimentacaoId);
        }
    }
}
