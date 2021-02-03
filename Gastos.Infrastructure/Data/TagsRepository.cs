using Gastos.Core.Interfaces;
using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Infrastructure.Data
{
    public class TagsRepository: ITagsRepository
    {
        private GastosContext _GastosContext;
        public TagsRepository(GastosContext gastosContext)
        {
            _GastosContext = gastosContext;
        }

        public async Task<List<object>> GetTagsByUsuario(string usuarioId)
        {
            return new List<object>();
        }
    }
}
