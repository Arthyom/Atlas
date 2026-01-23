using System;
using AutoMapper;
using Core.DTOs.Paquete;
using Core.Models.Entities;

namespace Core.Mappers;

public class ProfilePaquete : Profile
{
    public ProfilePaquete()
    {
        CreateMap<Paquete, DtoPaqueteResponse>()
        .ReverseMap();

         CreateMap<Paquete, DtoPaqueteRequest>()
        .ReverseMap();
    }
}
