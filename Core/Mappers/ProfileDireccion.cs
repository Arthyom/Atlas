using System;
using AutoMapper;
using Core.DTOs.Direccion;
using Core.DTOs.Direccion.Destino;
using Core.DTOs.Direccion.Origen;
using Core.Models.Entities;
using Core.Resolvers;

namespace Core.Mappers;

public class ProfileDireccion : Profile
{
    public ProfileDireccion()
    {
        CreateMap<Direccion,DtoDireccionResponse>()
        .ReverseMap();

        CreateMap<Direccion,Destino>()
        .ForPath(d => d.Direccion.City, opt => opt.MapFrom(s=> s.City))
        .ForPath(d => d.Direccion.Company, opt => opt.MapFrom(s=> s.Company))
        .ForPath(d => d.Direccion.Email, opt => opt.MapFrom(s=> s.Email))
        .ForPath(d => d.Direccion.InteriorNumber, opt => opt.MapFrom(s=> s.InteriorNumber))
        .ForPath(d => d.Direccion.Name, opt => opt.MapFrom(s=> s.Name))
        .ForPath(d => d.Direccion.Neighborhood, opt => opt.MapFrom(s=> s.Neighborhood))
        .ForPath(d => d.Direccion.OutdoorNumber, opt => opt.MapFrom(s=> s.OutdoorNumber))
        .ForPath(d => d.Direccion.Phone, opt => opt.MapFrom(s=> s.Phone))
        .ForPath(d => d.Direccion.References, opt => opt.MapFrom(s=> s.References))
        .ForPath(d => d.Direccion.State, opt => opt.MapFrom(s=> s.State))
        .ForPath(d => d.Direccion.Street, opt => opt.MapFrom(s=> s.Street))
        .ForPath(d => d.Direccion.ZipCode, opt => opt.MapFrom(s=> s.ZipCode))         
        .ReverseMap();

        CreateMap<Direccion,Origen>()
        .ForPath(d => d.Direccion.City, opt => opt.MapFrom(s=> s.City))
        .ForPath(d => d.Direccion.Company, opt => opt.MapFrom(s=> s.Company))
        .ForPath(d => d.Direccion.Email, opt => opt.MapFrom(s=> s.Email))
        .ForPath(d => d.Direccion.InteriorNumber, opt => opt.MapFrom(s=> s.InteriorNumber))
        .ForPath(d => d.Direccion.Name, opt => opt.MapFrom(s=> s.Name))
        .ForPath(d => d.Direccion.Neighborhood, opt => opt.MapFrom(s=> s.Neighborhood))
        .ForPath(d => d.Direccion.OutdoorNumber, opt => opt.MapFrom(s=> s.OutdoorNumber))
        .ForPath(d => d.Direccion.Phone, opt => opt.MapFrom(s=> s.Phone))
        .ForPath(d => d.Direccion.References, opt => opt.MapFrom(s=> s.References))
        .ForPath(d => d.Direccion.State, opt => opt.MapFrom(s=> s.State))
        .ForPath(d => d.Direccion.Street, opt => opt.MapFrom(s=> s.Street))
        .ForPath(d => d.Direccion.ZipCode, opt => opt.MapFrom(s=> s.ZipCode)) 
        .ReverseMap();


        CreateMap<Direccion, Direccion>()
        .ReverseMap();

        CreateMap<Origen,DtoApiEnPeOrigenResponse>() 
        .ForMember(d => d.city_origin, opt => opt.MapFrom(s=> s.Direccion.City))
        .ForMember(d => d.company_origin, opt => opt.MapFrom(s=> s.Direccion.Company))
        .ForMember(d => d.email_origin, opt => opt.MapFrom(s=> s.Direccion.Email))
        .ForMember(d => d.interior_number_origin, opt => opt.MapFrom(s=> s.Direccion.InteriorNumber))
        .ForMember(d => d.name_origin, opt => opt.MapFrom(s=> s.Direccion.Name))
        .ForMember(d => d.neighborhood_origin, opt => opt.MapFrom(s=> s.Direccion.Neighborhood))
        .ForMember(d => d.outdoor_number_origin, opt => opt.MapFrom(s=> s.Direccion.OutdoorNumber))
        .ForMember(d => d.phone_origin, opt => opt.MapFrom(s=> s.Direccion.Phone))
        .ForMember(d => d.references_origin, opt => opt.MapFrom(s=> s.Direccion.References))
        .ForMember(d => d.state_origin, opt => opt.MapFrom(s=> s.Direccion.State))
        .ForMember(d => d.street_origin, opt => opt.MapFrom(s=> s.Direccion.Street))
        .ForMember(d => d.zip_code_origin, opt => opt.MapFrom(s=> s.Direccion.ZipCode))



        // .ForPath(d => d, opt => opt.MapFrom<AtlasResolverOrigenApiResponse>())
        // .ForMember( d => d.Direccion, opt => opt.MapFrom( s => s))
        .ReverseMap();

        CreateMap<Destino,DtoApiEnPeDestinoResponse>()
        .ForMember(d => d.city_dest, opt => opt.MapFrom(s=> s.Direccion.City))
        .ForMember(d => d.company_dest, opt => opt.MapFrom(s=> s.Direccion.Company))
        .ForMember(d => d.email_dest, opt => opt.MapFrom(s=> s.Direccion.Email))
        .ForMember(d => d.interior_number_dest, opt => opt.MapFrom(s=> s.Direccion.InteriorNumber))
        .ForMember(d => d.name_dest, opt => opt.MapFrom(s=> s.Direccion.Name))
        .ForMember(d => d.neighborhood_dest, opt => opt.MapFrom(s=> s.Direccion.Neighborhood))
        .ForMember(d => d.outdoor_number_dest, opt => opt.MapFrom(s=> s.Direccion.OutdoorNumber))
        .ForMember(d => d.phone_dest, opt => opt.MapFrom(s=> s.Direccion.Phone))
        .ForMember(d => d.references_dest, opt => opt.MapFrom(s=> s.Direccion.References))
        .ForMember(d => d.state_dest, opt => opt.MapFrom(s=> s.Direccion.State))
        .ForMember(d => d.street_dest, opt => opt.MapFrom(s=> s.Direccion.Street))
        .ForMember(d => d.zip_code_dest, opt => opt.MapFrom(s=> s.Direccion.ZipCode))        
        .ReverseMap();

        CreateMap<Direccion,DtoDireccionRequest>()
        .ReverseMap();
    }

}
