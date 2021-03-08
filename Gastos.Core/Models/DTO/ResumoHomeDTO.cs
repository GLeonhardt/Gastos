using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Core.Models.DTO
{
    public class ResumoHomeDTO
    {
        public decimal Saldo { get; set; }
        public decimal Entradas { get; set; }
        public decimal Saidas { get; set; }
        public List<ResumoHomeMesDTO> Mensal { get; set; }
    }
}
