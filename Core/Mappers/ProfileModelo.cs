using System;
using AutoMapper;
using Core.Models.Entities;

namespace Core.Mappers;

public class ProfileModelo : Profile
{

    public ProfileModelo()
    {
        CreateMap<Modelo, DTOs.Modelo.DtoModeloResponse>()
        .ForMember(dest => dest.imagenes, opt => opt.MapFrom(src => src.ImagenModelos))
        .ReverseMap();

         CreateMap<Modelo, DTOs.Modelo.DtoModeloRequest>()
        .ReverseMap();


        CreateMap<ImagenModelo, string>()
        .ConvertUsing(x => x.Imagen.Identificador);
        // .ForMember(dest => dest, opt => opt.MapFrom(src => src.Imagen.Identificador))

    }

}
