using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Core.Models.DTO
{
    public class RelatorioMensallDTO
    {
        public string Periodo { get; set; }
        public int Quantidade { get; set; }
        public decimal Saldo { get; set; }
        public decimal Entrada { get; set; }
        public decimal Saida { get; set; }
        public List<RelatorioMensalMovimentacoesDTO> Movimentacoes { get; set; } = new List<RelatorioMensalMovimentacoesDTO>();
        
    }
}
