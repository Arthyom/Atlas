using System;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Categoria;

namespace Core.Mappers;

public class ProfileCategoria : Profile
{
    public ProfileCategoria()
    {
        CreateMap<Categoria, DtoCategoriaResponse>()
        .ForMember(x => x.ProductosAsociados, opt => opt.MapFrom(src => src.Productos.Count))
        .ReverseMap();

        CreateMap<Categoria, DtoCategoriaRequest>()
        
        .ReverseMap();
    }
}
