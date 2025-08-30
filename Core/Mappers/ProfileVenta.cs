using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Venta;
using Core.Helpers;
using Core.Models.Entities;

namespace Core.Mappers
{
    public class ProfileVenta : Profile
    {
        public ProfileVenta()
        {
            CreateMap<DtoVentaRequest, Venta>()
            .ForMember(dest => dest.ProductoVenta, opt => opt.MapFrom(src => map(src)))
            .ForMember(dest => dest.Folio, opt => opt.MapFrom( src => AtlasHelperUtilities.CreateNLengGUID(12).SplitByDashes(4) ) )
            .ReverseMap();


            CreateMap<Venta, DtoVentaResponse>()
            .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => mapEntityToKeyValue(src.ProductoVenta)))
            .ForMember(dest => dest.TotalProductos, opt => opt.MapFrom(src=> src.ProductoVenta.Count() ))
            .ReverseMap();
        }

        private static IEnumerable<DtoKeyValue> mapEntityToKeyValue(ICollection<ProductoVenta> venta)
        {
            return venta.MapBaseEntityToExplicitKeyValue( "ProductoId", venta.Count().ToString());
        }

        private static List<ProductoVenta> map(DtoVentaRequest dto)
        {
            var map = new List<ProductoVenta>();

            dto.Productos.ForEach(x =>
            {
                map.Add(new ProductoVenta() { ProductoId = x.Key });
            });

            return map;
        }
    }
}