using AutoMapper;
using Gastos.Core.Interfaces;
using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gastos.Infrastructure.Data
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private GastosContext _GastosContext;
        private IMapper _IMapper;
        public MovimentacaoRepository(GastosContext gastosContext, IMapper autoMapper)
        {
            _GastosContext = gastosContext;
            _IMapper = autoMapper;
        }
    }
}
