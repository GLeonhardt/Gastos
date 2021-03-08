using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Core.Models.DTO
{
    public class RelatorioMensalMovimentacoesDTO
    { 
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
