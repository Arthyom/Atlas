using System;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;

namespace Core.Mappers;

public class ProfileProducto : Profile
{

    public ProfileProducto()
    {

        CreateMap<Producto, DtoProductoRequst>()

            .ReverseMap();


        CreateMap<Producto, DtoProductoResponse>()
        .ForMember(x => x.imagenes, opt => opt.MapFrom(src => src.ImagenProductos))
        .ForMember(x => x.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
        .ForMember(x => x.CategoriaColor, opt => opt.MapFrom(src => src.Categoria.Color))

            // .IncludeMembers(p => p.ImagenProductos)
            // .ReverseMap();


            ;


        CreateMap<ImagenProducto, string>()
       .ConvertUsing(x=> x.Imagen.Identificador)
        ;

    }


    private static List<string>? toFilesString(Producto p)
    {
        List<string> names = new List<string>();
        if (p.ImagenProductos == null) return null;

        foreach (var item in p.ImagenProductos)
        {
            names.Add(item.Imagen.Identificador);
        }
        
        return names;
    }
}
