using System;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Api.Response;

namespace Core.Mappers;

public class ProfileOrder : Profile
{
    public ProfileOrder()
    {
        CreateMap<DtoOrder, DtoOrder>()
        .ReverseMap();

        CreateMap<DtoItem, DtoApiRequestItem>()
        .ReverseMap();

        CreateMap<DtoOrder, DtoApiRequestOrder>()
        .ReverseMap();

        CreateMap<DtoEstado, DtoApiRequestEstado>()
        .ReverseMap();

        CreateMap<DtoPais, DtoApiRequestPais>()
        .ReverseMap();

        CreateMap<DtoAddress, DtoApiRequestAddress>()
        .ReverseMap();

        CreateMap<DtoApiResponseOrder, DtoOrderResponse>()
        .ForMember( x  => x.Id, opt => opt.Ignore())
        .ForMember( x => x.Folio, opt => opt.MapFrom( f => f.id ))
        
        .ReverseMap();
    }
}
