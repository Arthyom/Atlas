using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;

namespace Core.Mappers
{
    public class ProfileUsuario : Profile
    {
        public ProfileUsuario()
        {
            CreateMap<Usuario, DtoUsuarioResponse>()
            .ForMember( d => d.Company , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.Company : ""))
            .ForMember( d => d.Country , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.CountryName : ""))
            .ForMember( d => d.CountryCode , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.CountryCode : ""))
            .ForMember( d => d.InteriorNumber , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.InteriorNumber : ""))
            .ForMember( d => d.OutdoorNumber , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.OutdoorNumber : ""))
            .ForMember( d => d.ZipCode , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.ZipCode : ""))
            .ForMember( d => d.StateCode , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.StateCode : ""))
            .ForMember( d => d.State , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.State : ""))
            .ForMember( d => d.References , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.References : ""))
            .ForMember( d => d.Phone , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.Phone : ""))
            .ForMember( d => d.Neighborhood , opt => opt.MapFrom( s => s.Origen !=null  ? s.Origen.Direccion.Neighborhood : ""))
            .ForMember( d => d.Rol , opt => opt.MapFrom( s => s.Rol !=null  ? s.Rol.Name : ""))


            .ReverseMap();
        }
    }
}