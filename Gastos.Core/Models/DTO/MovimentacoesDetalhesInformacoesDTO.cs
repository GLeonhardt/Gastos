using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Core.Models.DTO
{
    public class MovimentacoesDetalhesInformacoesDTO
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public List<string> Tags { get; set; }
    }
}
