using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Gastos.Infrastructure.Models
{
    public partial class Usuarios : IdentityUser
    {
        public string Nome { get; set; }

        public virtual List<Movimentacoes> Movimentacoes { get; set; } = new List<Movimentacoes>();
        public virtual List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
