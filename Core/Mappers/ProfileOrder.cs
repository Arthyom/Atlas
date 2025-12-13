using System;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Api.Response;
using Core.Models.Entities;

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
        .ForMember( x => x.Folio, opt => opt.MapFrom( f => f.id ));

        CreateMap<Order, DtoApiRequestOrder>()
        .ForMember(x => x.folio, opt => opt.MapFrom( o => o.ApiId))
        .ForMember( x => x.first_name, opt => opt.MapFrom( o => o.Customer.FirtName ))
        .ForMember( x => x.email, opt => opt.MapFrom( o => o.Customer.Email ))
        .ForMember(x => x.shipping_address, opt => opt.MapFrom( o => createAddressFromOrder(o)))
        .ForMember(x => x.items, opt => opt.MapFrom( o => createItemsFromOrder(o)))
        
        .ReverseMap();
    }

    private static IEnumerable<DtoApiRequestItem> createItemsFromOrder(Order order)
    {
        List<DtoApiRequestItem> items = new List<DtoApiRequestItem>();
        
        order.Productos.ToList().ForEach( p => 
        {
            int totalItems = order.Productos.Count(p => p.Id == p.Id);
            items.Add( new DtoApiRequestItem
            {
                name = p.Nombre,
                quantity = totalItems,
                price = 0
            });
        });

        return items;
    }


    private static DtoApiRequestAddress createAddressFromOrder(Order order)
    {
        return new DtoApiRequestAddress
        {
          address1 = order.Direccion.Street,
          address2 = order.Direccion.Street,
          city = order.Direccion.City,
          postal_code = order.Direccion.ZipCode,
          phone = order.Direccion.Phone,
          first_name = order.Customer.FirtName,
          last_name = order.Customer.LastName,
          state = new DtoApiRequestEstado
          {
              code = order.Direccion.StateCode
          },
          country = new DtoApiRequestPais
          {
              code = order.Direccion.CountryCode,
              name = order.Direccion.CountryName 
          },
        };
    }
}
