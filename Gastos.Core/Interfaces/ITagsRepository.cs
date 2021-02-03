using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Core.Interfaces
{
    public interface ITagsRepository
    {
        Task<List<object>> GetTagsByUsuario(string usuarioId);
    }
}
