using Gastos.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Web.Models
{
    public class MovimentacaoPost
    {
        public DateTime Data { get; set; }
        public EnumTipoMovimentacao TipoMovimentacao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public List<long> Tags { get; set; } = new List<long>();

    }
}
