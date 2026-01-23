using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Guia;
using Core.DTOs.Guias;

namespace Core.Mappers
{
    public class ProfileGuide : Profile
    {
        public ProfileGuide()
        {
            CreateMap<DtoGuiaEnPeResponse, DtoGuiaResponse>()
            .ForMember( d => d.Info, opt => opt.MapFrom( s => s.pdf))
            .ReverseMap();
        }
    }
}