using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Direccion.Destino;
using Core.DTOs.Direccion.Origen;
using Core.DTOs.Envio;
using Core.Models.Entities;
using Core.Resolvers;

namespace Core.Mappers
{
    public class ProfileEnvio : Profile
    {
        public ProfileEnvio()
        {

            CreateMap<Envio, DtoEnvioRequest>()
            .ReverseMap();

            CreateMap<Envio, DtoEnvioResponse>()
            .ForMember( d => d.Origin, opt => opt.MapFrom( s => s.Origen.Direccion))
            .ForMember( d => d.Destination, opt => opt.MapFrom( s => s.Destino.Direccion))
            // .ForMember(d => d.Order, opt => opt.MapFrom( s => s.Order))
            .ReverseMap();




            CreateMap<Envio, DtoApiEnPeEnvioRequest>()
            // .ForMember(x => x.ProductosAsociados, opt => opt.MapFrom(src => src.Productos.Count))
            .ReverseMap();


                             

            CreateMap<Envio, DtoApiEnPeEnvioResponse>()
            // .ForMember(s => s.State , d => d.MapFrom( src => "created"))
            // .ForMember(s => s.Folio , d => d.MapFrom( src => src.Order.ApiId))
            // .ForMember( d => d.Origen,  opt => opt.MapFrom<AtlasResolverDestinoApiResponse,DtoApiEnPeOrigenResponse >( s => new DtoApiEnPeOrigenResponse (  ) ))
            .ForPath( d => d.Origin, opt => opt.MapFrom( s => new DtoApiEnPeOrigenResponse()
            {
                city_origin = s.Origen.Direccion.City,
                email_origin = s.Origen.Direccion.Email,
                company_origin = s.Origen.Direccion.Company,
                interior_number_origin = s.Origen.Direccion.InteriorNumber,
                name_origin = s.Origen.Direccion.Name,
                neighborhood_origin = s.Origen.Direccion.Neighborhood,
                outdoor_number_origin = s.Origen.Direccion.OutdoorNumber,
                phone_origin = s.Origen.Direccion.Phone,
                references_origin = s.Origen.Direccion.References,
                state_origin = s.Origen.Direccion.State,
                street_origin = s.Origen.Direccion.Street,
                zip_code_origin = s.Origen.Direccion.ZipCode
            }))
            .ForPath( d => d.Destination, opt => opt.MapFrom( s => new DtoApiEnPeDestinoResponse()
            {
                city_dest = s.Destino.Direccion.City,
                email_dest = s.Destino.Direccion.Email,
                company_dest = s.Destino.Direccion.Company,
                interior_number_dest = s.Destino.Direccion.InteriorNumber,
                name_dest = s.Destino.Direccion.Name,
                neighborhood_dest = s.Destino.Direccion.Neighborhood,
                outdoor_number_dest = s.Destino.Direccion.OutdoorNumber,
                phone_dest = s.Destino.Direccion.Phone,
                references_dest = s.Destino.Direccion.References,
                state_dest = s.Destino.Direccion.State,
                street_dest = s.Destino.Direccion.Street,
                zip_code_dest = s.Destino.Direccion.ZipCode
            }))
            .ForMember( d => d.PackageSize, opt => opt.MapFrom( src => src.Paquete) )
            .ForMember( s => s.Order, d => d.MapFrom( src => src.Order))
            .ReverseMap();


            CreateMap<Envio, DtoApiEnPeEnvioRequest>()
            .ForMember(s => s.State , d => d.MapFrom( src => "created"))
            .ForMember(s => s.Folio , d => d.MapFrom( src => src.Order.ApiId))
            .ForMember( s => s.Orden, d => d.MapFrom( src => src.Order))
            .ReverseMap();
        }

        
    }
}