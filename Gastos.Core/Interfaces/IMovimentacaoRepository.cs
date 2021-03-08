using Gastos.Core.DTO;
using Gastos.Core.Models.DTO;
using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Core.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task<long> Create(Movimentacoes movimentacoes, List<long> tags);
        MovimentacoesInformacoesDTO GetMovimentacao(string userId, long movimentacaoId);
        RelatorioMensallDTO GetRelatorioMovimentacoesMes(string userId, int mes, int ano);
        ResumoHomeDTO GetResumoHome(string usuarioId, DateTime dataInicial, DateTime dataFinal, List<long> tags);
        Task<bool> ExcluirMovimentacao(string usuarioId, long movimentacaoId);
    }
}
