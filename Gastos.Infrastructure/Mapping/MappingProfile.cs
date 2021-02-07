using AutoMapper;
using Gastos.Core.DTO;
using Gastos.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tags, TagsDTO>().ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.TagId));
        }
    }
}
