using System;
using System.Collections.Generic;

#nullable disable

namespace Gastos.Infrastructure.Models
{
    public partial class Movimentacoes
    {

        public long MovimentacaoId { get; set; }
        public string UsuarioId { get; set; }
        public long TipoMovimentacaoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public TipoMovimentacoes TipoMovimentacao { get; set; }
        public Usuarios Usuario { get; set; }
        public List<Detalhes> Detalhes { get; set; } = new List<Detalhes>();
        public List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
