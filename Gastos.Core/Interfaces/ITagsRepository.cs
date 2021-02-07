using Gastos.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Core.Interfaces
{
    public interface ITagsRepository
    {
        Task<List<TagsDTO>> GetTagsByUsuario(string usuarioId);
        Task<bool> CreateTagUsuario(string usuarioId, string tag);
        Task<bool> DeleteTagUsuario(string usuarioId, long tagId);

    }
}
