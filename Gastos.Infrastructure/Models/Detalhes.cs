using System;
using System.Collections.Generic;

#nullable disable

namespace Gastos.Infrastructure.Models
{
    public partial class Detalhes
    {

        public long DetalheId { get; set; }
        public long MovimentacaoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Movimentacoes Movimentacao { get; set; }
        public List<Tags> Tags { get; set; } = new List<Tags>();
        
    }
}
