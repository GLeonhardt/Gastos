using Gastos.Core.DTO;
using Gastos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gastos.Core.Services
{
    public class TagsService
    {
        private readonly ITagsRepository _tagsRepository;
        public TagsService(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }


        public async Task<List<TagsDTO>> GetTagsByUsuario(string usuarioId)
        {
            return await _tagsRepository.GetTagsByUsuario(usuarioId);
        }

        public async Task<bool> CreateTagUsuario(string usuarioId, string tag)
        {
            return await _tagsRepository.CreateTagUsuario(usuarioId, tag);
        }

        public async Task<bool> DeleteTagUsuario(string usuarioId, long tagId)
        {
            return await _tagsRepository.DeleteTagUsuario(usuarioId, tagId);
        }


        public async Task<TagsDTO> BuscarTagById(string usuarioId, long tagId)
        {
            var tag = await _tagsRepository.GetTagsByUsuario(usuarioId);

            return tag.Where(x => x.Id == tagId).SingleOrDefault();
        }
    }
}
