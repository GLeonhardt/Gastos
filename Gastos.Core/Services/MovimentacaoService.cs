using Gastos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Core.Services
{
    public class MovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }
    }
}
