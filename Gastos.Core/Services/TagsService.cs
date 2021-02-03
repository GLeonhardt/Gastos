using Gastos.Core.Interfaces;
using System;
using System.Collections.Generic;
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


        public async Task<List<object>> GetTagsByUsuario(string usuarioId)
        {
            return await _tagsRepository.GetTagsByUsuario(usuarioId);
        }
    }
}
