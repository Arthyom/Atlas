using System;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Api.Response;
using Core.DTOs.Direccion.Destino;
using Core.DTOs.Envio;
using Core.DTOs.Shared;
using Core.Models.Entities;

namespace Core.Mappers;

public class ProfileOrder : Profile
{
    private static DtoApiECartAddressRequest createApiShippingAddressFromSharedDto(DtoSharedApiEnvioOrdenRequest order)
    {
        return new DtoApiECartAddressRequest()
        {
            address1 = order.shipping_address.address1,
            address2 = "",
            city = order.envios.First().Destino.city_dest,
            postal_code = order.envios.First().Destino.zip_code_dest,
            phone = order.envios.First().Destino.phone_dest,
            first_name = order.Customer.first_name,
            last_name = order.Customer.last_name,
            state = new  DtoApiECartEstadoRequest 
            {
                // code = order.envios.First().Destino.state_code_dest
                code = order.shipping_address.state.code

            },
            country = new  DtoApiECartPaisRequest 
            {
                // code = order.envios.First().Destino.country_code_dest,
                // name = order.envios.First().Destino.country_code_name

                code = order.shipping_address.country.code,
                name = order.shipping_address.country.name,
            },
        };
    }

    private static IEnumerable<DtoItem> createApiItemsFromSharedDto(DtoSharedApiEnvioOrdenRequest order)
    {
        List<DtoItem> items = new List<DtoItem>();
        
        order.items.ToList().ForEach( p => 
        {
            items.Add( new DtoItem
            {
                name = p.Nombre,
                Id = p.Id,
                price = 1,
                quantity = 1
            });
        });

        return items;
    }

    public ProfileOrder()
    {
        CreateMap< DtoSharedApiEnvioOrdenRequest, DtoApiECartOrderRequest>()
        .ForMember(dest => dest.email , opt => opt.MapFrom(s => s.Customer.email))
        .ForMember(dest => dest.first_name , opt => opt.MapFrom(s => s.Customer.first_name))
        .ForMember(dest => dest.last_name , opt => opt.MapFrom(s => s.Customer.last_name))
        .ForMember(dest => dest.phone , opt => opt.MapFrom(s => s.Customer.phone))
        .ForMember(dest => dest.currency , opt => opt.MapFrom(s => s.Currency))
        .ForMember(dest => dest.items , opt => opt.MapFrom( s => createApiItemsFromSharedDto(s)))
        .ForMember(dest => dest.shipping_address , opt => opt.MapFrom( s => createApiShippingAddressFromSharedDto(s)))
        .ReverseMap();

        CreateMap<Order, DtoSharedApiEnvioOrdenRequest>()
        .ForMember(x => x.ApiCustomerId, opt => opt.MapFrom( o => Guid.NewGuid().ToString()))
        .ForMember(x => x.folio, opt => opt.MapFrom( o => o.ApiId))
        // .ForMember( x => x.first_name, opt => opt.MapFrom( o => o.Customer.FirtName ))
        // .ForMember( x => x.email, opt => opt.MapFrom( o => o.Customer.Email ))
        // .ForMember(x => x.shipping_address, opt => opt.MapFrom( o => createAddressFromOrder(o)))
        // .ForMember(x => x.items, opt => opt.MapFrom( o => createItemsFromOrder(o)))
        .ForMember( dest => dest.Customer, opt => opt.MapFrom( o => new Customer()
        {
            FirtName = o.Customer.FirtName,
            LastName = o.Customer.LastName,
            Email = o.Customer.Email,
            Phone = o.Customer.Phone,
            ApiCustomerId = o.Customer.ApiCustomerId
        }))

        ;
    

        CreateMap<DtoSharedApiEnvioOrdenRequest, Order>()
        // .ForMember(dest => dest.Direccion, opt => opt.MapFrom(o => new Direccion
        // {
        //     Street = o.shipping_address.address1,
        //     City = o.shipping_address.city,
        //     ZipCode = o.shipping_address.postal_code,
        //     Phone = o.shipping_address.phone,
        //     StateCode = o.shipping_address.state.code,
        //     CountryCode = o.shipping_address.country.code,
        //     CountryName = o.shipping_address.country.name ,
        //     State = o.envios.First().Destino.state_dest,
        //     References = o.envios.First().Destino.state_dest,
        //     Company = o.envios.First().Destino.company_dest,
        //     Email = o.envios.First().Destino.email_dest,
        //     InteriorNumber = o.envios.First().Destino.interior_number_dest,
        //     OutdoorNumber = o.envios.First().Destino.outdoor_number_dest,
        //     Neighborhood = o.envios.First().Destino.neighborhood_dest,
        //     Name = o.Customer.first_name,
        // }))
        .ForMember(x => x.ApiId, opt => opt.MapFrom( o => o.folio))
        // .ForMember( x => x.Customer, opt => opt.MapFrom( o => createCustomerFromOrder(o))) 
        // .ForMember( x => x.ema, opt => opt.MapFrom( o => o.email ))
        // .ForMember(x => x.Direccion, opt => opt.MapFrom( o => createAddressFromSharedOrder(o)))
        .ForMember(x => x.Envios, opt => opt.MapFrom( o => createEnviosFromSharedOrder(o)))
        // .ForMember(x => x.Productos, opt => opt.MapFrom( o => createProductosFromSharedOrderEnvio(o)))   
        .ForMember(dest => dest.ProductoOrder , opt => opt.MapFrom( o => createProductosOrderFromSharedOrderEnvio(o)))
        .ForMember( dest => dest.Customer , opt => opt.MapFrom( o => createCustomerFromOrder(o))    )
        ;

        CreateMap<DtoOrderRequest, DtoOrderRequest>()
        .ReverseMap();

        CreateMap<DtoItem, DtoApiECartItemRequest>()
        .ReverseMap();

        CreateMap<DtoOrderRequest, DtoApiECartOrderRequest>()
        .ReverseMap();

        CreateMap<DtoEstado, DtoApiECartEstadoRequest>()
        .ReverseMap();

        CreateMap<DtoPais, DtoApiECartPaisRequest >()
        .ReverseMap();

        CreateMap<DtoOrderRequest, DtoApiECartOrderRequest>()
        .ReverseMap();

        CreateMap<DtoApiECartOrderResponse , DtoOrderResponse>()
        .ForMember( x  => x.Id, opt => opt.Ignore())
        .ForMember( x => x.folio, opt => opt.MapFrom( f => f.id ));

        CreateMap<Order, DtoOrderResponse>()
        .ForMember( x => x.folio, opt => opt.MapFrom( d => d.ApiId))
        .ForMember( d => d.Status, opt => opt.MapFrom(d => d.ApiStatus))
        .ForMember( x => x.Productos , opt => opt.MapFrom( d => d.Productos))
        .ForMember( x => x.Envios, opt => opt.MapFrom(d => d.Envios))
        // .ForMember(x => x.Direccion, opt => opt.MapFrom(d => d.Direccion))
        .ReverseMap();

        CreateMap<Order,  DtoApiECartOrderRequest >()
        // .ForMember(x => x.folio, opt => opt.MapFrom( o => o.ApiId))
        .ForMember( x => x.first_name, opt => opt.MapFrom( o => o.Customer.FirtName ))
        .ForMember( x => x.email, opt => opt.MapFrom( o => o.Customer.Email ))
        // .ForMember(x => x.shipping_address, opt => opt.MapFrom( o => createAddressFromOrder(o)))
        .ForMember(x => x.items, opt => opt.MapFrom( o => createItemsFromOrder(o)))
        .ReverseMap();

        CreateMap<Order, DtoApiECartOrderResponse>()
        .ForMember(x => x.id, opt => opt.MapFrom( o => o.ApiId))
        .ForMember(x => x.Folio, opt => opt.MapFrom( o => o.ApiId))
        .ForMember(x => x.status, opt => opt.MapFrom( o => o.ApiStatus))
        

        // .ForMember( x => x.first_name, opt => opt.MapFrom( o => o.Customer.FirtName ))
        // .ForMember( x => x.email, opt => opt.MapFrom( o => o.Customer.Email ))
        // .ForMember(x => x.shipping_address, opt => opt.MapFrom( o => createAddressFromOrder(o)))
        .ForMember(x => x.Productos, opt => opt.MapFrom( o => createItemsFromOrder(o)))
        .ReverseMap();    }

    private static IEnumerable<Producto> createProductosFromSharedOrderEnvio(DtoSharedApiEnvioOrdenRequest order)
    {
        List<Producto> items = new List<Producto>();
        
        order.items.ToList().ForEach( p => 
        {
            // int totalItems = order.Productos.Count(p => p.Id == p.Id);
            items.Add( new Producto
            {
                ProductoOrder = new List<ProductoOrder>
                {
                    new ProductoOrder
                    {
                        ProductoId = p.Id
                    }
                },
            });
        });

        return items;
    }

    private static IEnumerable<ProductoOrder> createProductosOrderFromSharedOrderEnvio(DtoSharedApiEnvioOrdenRequest order)
    {
        List<ProductoOrder> items = new List<ProductoOrder>();
        
        order.items.ToList().ForEach( p => 
        {
            // int totalItems = order.Productos.Count(p => p.Id == p.Id);
            items.Add( new ProductoOrder
            {
                ProductoId = p.Id
            });
        });

        return items;
    }


    private static IEnumerable<DtoProductoResponse> createItemsFromOrder(Order order)
    {
        List<DtoProductoResponse> items = new List<DtoProductoResponse>();
        
        order.Productos.ToList().ForEach( p => 
        {
            int totalItems = order.Productos.Count(p => p.Id == p.Id);
            items.Add( new DtoProductoResponse
            {
                Nombre = p.Nombre,
                Id = p.Id,
                Cantidad = totalItems,
                PrecioUnitario = p.PrecioUnitario,
                PrecioMayoreo = p.PrecioMayoreo
            });
        });

        return items;
    }

    private static Customer createCustomerFromOrder(DtoSharedApiEnvioOrdenRequest order)
    {
        return  new Customer()
        {
            ApiCustomerId = Guid.NewGuid().ToString(),
            Email = order.Customer.email,
            FirtName = order.Customer.first_name,
            LastName = order.Customer.last_name,
            Phone = order.Customer.phone
        };
    }



    private static List<Envio> createEnviosFromSharedOrder(DtoSharedApiEnvioOrdenRequest order)
    {
        
        List<Envio> envios = new List<Envio>();

        if(order.envios != null)
        {
            
        order.envios.ToList().ForEach( e => 
        {
            envios.Add( new Envio
            {
                    DeliveryType = e.DeliveryType != null ? e.DeliveryType : "",
                    Status = e.Status.HasValue ? e.Status.Value : 0,

                    Destino = createDestinoFromEnvio(e),
                    Origen = createOrigenFromEnvio(e),
                    Paquete = createPaqueteFromEnvio(e),
                



                // ApiTipoServicio = e.service_type,
                // ApiTrackingNumber = e.tracking_number,
                // ApiCarrier = e.carrier,
                // Coste = e.cost,
                });
            });
        }

        return envios;
    }

    private static Paquete? createPaqueteFromEnvio(DtoApiEnPeEnvioRequest envio)
    {
        if(envio.Paquete != null)
        {
            return new Paquete()
            {
                Description = envio.Paquete.Description,
                Depth = envio.Paquete.Depth,
                Height = envio.Paquete.Height,
                Type = envio.Paquete.Type,
                Weight = envio.Paquete.Weight,
                Width = envio.Paquete.Width,
            };
        }

        return null;
    }


    private static Destino createDestinoFromEnvio(DtoApiEnPeEnvioRequest envio)
    {
        return new Destino()
        {
           Direccion = new Direccion
           {
              Company = envio.Destino.company_dest,
              Street = envio.Destino.street_dest,
              InteriorNumber = envio.Destino.interior_number_dest,
              OutdoorNumber = envio.Destino.outdoor_number_dest,
              ZipCode = envio.Destino.zip_code_dest,
              Neighborhood = envio.Destino.neighborhood_dest,
              City = envio.Destino.city_dest,
              State = envio.Destino.state_dest,
              References = envio.Destino.references_dest,
              Email = envio.Destino.email_dest,
              Phone = envio.Destino.phone_dest,
              Name = envio.Destino.name_dest,
              StateCode = "GTO",//envio.Destino.state_code_dest,
              CountryCode = "MX",//envio.Destino.country_code_dest,
              CountryName = "Mexico" //envio.Destino.country_code_name
           }, 
        };
    }

    private static Origen? createOrigenFromEnvio(DtoApiEnPeEnvioRequest envio)
    {
        if(envio.Origen != null)
        {
            return new Origen()
            {
                Direccion = new Direccion
                {
                //   Company = envio,
                //   Street = envio.street_dest,
                //   InteriorNumber = envio.interior_number_dest,
                //   OutdoorNumber = envio.outdoor_number_dest,
                //   ZipCode = envio.zip_code_dest,
                //   Neighborhood = envio.neighborhood_dest,
                //   City = envio.city_dest,
                //   State = envio.state_dest,
                //   References = envio.references_dest,
                //   Email = envio.email_dest,
                //   Phone = envio.phone_dest,
                //   Name = envio.name_dest,  
                }, 
            };
        }

        return null;
    }



    private static Direccion createAddressFromSharedOrder(DtoSharedApiEnvioOrdenRequest order)
    {
        return new Direccion
        {
          Street = order.shipping_address.address1,
          City = order.shipping_address.city,
          ZipCode = order.shipping_address.postal_code,
          Phone = order.shipping_address.phone,
          StateCode = order.shipping_address.state.code,
          CountryCode = order.shipping_address.country.code,
          CountryName = order.shipping_address.country.name ,
          State = order.envios.First().Destino.state_dest,
          References = order.envios.First().Destino.state_dest,
          Company = order.envios.First().Destino.company_dest,
          Email = order.envios.First().Destino.email_dest,
          InteriorNumber = order.envios.First().Destino.interior_number_dest,
          OutdoorNumber = order.envios.First().Destino.outdoor_number_dest,
          Neighborhood = order.envios.First().Destino.neighborhood_dest,
          Name = order.Customer.first_name,
          

        };
    }  



    // private static DtoApiECartAddressRequest createAddressFromOrder(Order order)
    // {
    //     return new DtoApiECartAddressRequest  
    //     {
    //       address1 = order.Direccion.Street,
    //       address2 = order.Direccion.Street,
    //       city = order.Direccion.City,
    //       postal_code = order.Direccion.ZipCode,
    //       phone = order.Direccion.Phone,
    //       first_name = order.Customer.FirtName,
    //       last_name = order.Customer.LastName,
    //       state = new  DtoApiECartEstadoRequest 
    //       {
    //           code = order.Direccion.StateCode
    //       },
    //       country = new  DtoApiECartPaisRequest 
    //       {
    //           code = order.Direccion.CountryCode,
    //           name = order.Direccion.CountryName 
    //       },
    //     };
    // }
}
