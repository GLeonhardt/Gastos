using AutoMapper;
using Gastos.Core.DTO;
using Gastos.Core.Interfaces;
using Gastos.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Infrastructure.Data
{
    public class TagsRepository: ITagsRepository
    {
        private GastosContext _GastosContext;
        private IMapper _IMapper;
        public TagsRepository(GastosContext gastosContext, IMapper autoMapper)
        {
            _GastosContext = gastosContext;
            _IMapper = autoMapper;
        }

        public async Task<List<TagsDTO>> GetTagsByUsuario(string usuarioId)
        {
            var tags = await _GastosContext.Tags.Where(x => x.UsuarioId == usuarioId).ToListAsync();
            return _IMapper.Map<List<TagsDTO>>(tags);
        }

        public async Task<bool> CreateTagUsuario(string usuarioId, string tag)
        {
            _GastosContext.Tags.Add(new Tags { UsuarioId = usuarioId, Tag = tag });
            await _GastosContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTagUsuario(string usuarioId, long tagId)
        {
            var tag = await _GastosContext.Tags.Where(x => x.UsuarioId == usuarioId && x.TagId == tagId).SingleOrDefaultAsync();

            if (tag is null)
                throw new Exception($"Tag não encontrada");

            _GastosContext.Remove(tag);
            await _GastosContext.SaveChangesAsync();
            return true;
        }
    }
}
