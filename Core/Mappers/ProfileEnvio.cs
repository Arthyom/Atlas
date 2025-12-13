using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Envio;
using Core.Models.Entities;

namespace Core.Mappers
{
    public class ProfileEnvio : Profile
    {
        public ProfileEnvio()
        {
            CreateMap<Envio, DtoApiRequestEnvio>()
            // .ForMember(x => x.ProductosAsociados, opt => opt.MapFrom(src => src.Productos.Count))
            .ReverseMap();

            CreateMap<Envio, DtoApiResponseEnvio>()
            .ForMember(s => s.State , d => d.MapFrom( src => "created"))
            .ForMember(s => s.Folio , d => d.MapFrom( src => src.Order.ApiId))
            .ForMember( s => s.Orden, d => d.MapFrom( src => src.Order))
        
            .ReverseMap();
        }

        
    }
}