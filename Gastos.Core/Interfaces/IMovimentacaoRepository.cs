using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Core.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task<bool> Create(Movimentacoes movimentacoes, List<long> tags);
    }
}
