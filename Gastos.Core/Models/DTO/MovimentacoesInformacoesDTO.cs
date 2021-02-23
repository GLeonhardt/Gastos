using Gastos.Core.Models.DTO;
using Gastos.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Core.DTO
{
    public class MovimentacoesInformacoesDTO
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public EnumTipoMovimentacao TipoMovimentacao { get; set; }
        public List<MovimentacoesDetalhesInformacoesDTO> Detalhes { get; set; } = new List<MovimentacoesDetalhesInformacoesDTO>();
        public List<string> Tags { get; set; } = new List<string>();

    }
}
