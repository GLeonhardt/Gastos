using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Gastos.Infrastructure.Models
{
    public partial class Usuarios : IdentityUser
    {
        //public long UsuarioId { get; set; }
        public string Nome { get; set; }
        //public string Email { get; set; }
        //public string Senha { get; set; }

        public virtual List<Movimentacoes> Movimentacoes { get; set; } = new List<Movimentacoes>();
        public virtual List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
