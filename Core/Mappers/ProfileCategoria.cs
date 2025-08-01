using System;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;

namespace Core.Mappers;

public class ProfileCategoria : Profile
{
    public ProfileCategoria()
    {
        CreateMap<Categoria, DtoCategoriaResponse>()
        .ReverseMap();
    }
}
