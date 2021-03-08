using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Core.Models.DTO
{
    public class ResumoHomeMesDTO
    {
        public DateTime Mes { get; set; }
        public decimal Saldo { get; set; }
        public decimal Entradas { get; set; }
        public decimal Saidas { get; set; }
        public int QuantidadeMovimentacoes { get; set; }
    }
}
