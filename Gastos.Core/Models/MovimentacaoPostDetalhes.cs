﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Core.Models
{
    public class MovimentacaoPostDetalhes
    {
        public string Detalhe { get; set; }
        public decimal Valor { get; set; }
        public List<long> Tags { get; set; } = new List<long>();
    }
}
