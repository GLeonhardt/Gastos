using System;
using System.Collections.Generic;

#nullable disable

namespace Gastos.Infrastructure.Models
{
    public partial class Tags
    {
        public long TagId { get; set; }
        public string Tag { get; set; }
        public string UsuarioId { get; set; }

        public Usuarios Usuario { get; set; }

        public List<Movimentacoes> Movimentacoes { get; set; } = new List<Movimentacoes>();
        public List<Detalhes> Detalhes { get; set; } = new List<Detalhes>();
    }
}
