using System;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Api.Response;
using Core.DTOs.Base;
using Core.DTOs.Shared;
using Core.Models.Entities;
using Core.Seeder.Data;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Services.Implementations;

public class OrderService : AtlasBaseServiceMixed<Order, DtoSharedApiEnvioOrdenRequest, DtoOrderResponse>, IOrderService
{
    private readonly IConfiguration _config;
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly HttpClient _httpClient;

    public OrderService(IUnitOfWork UoW, IMapper mapper, IConfiguration config, IHttpClientFactory clientFactory) : base(UoW, mapper)
    {
        _config = config;
        _httpClientFactory = clientFactory;

        _httpClient = _httpClientFactory.CreateClient("PaymentServiceCliente");
    } 

    public override async Task<AtlasMixedResponse<DtoOrderResponse>> GetAll()
    {
        AtlasMixedResponse<DtoOrderResponse> response = new AtlasMixedResponse<DtoOrderResponse>();
        
        var unMappedResponse  =  await UoW.GetRepo<Order>()
                                    .DbSet
                                    .Include(o => o.Customer)
                                    // .Include(o => o.Direccion)
                                    .Include(o => o.Envios)
                                    .Include(o => o.Productos)
                                    
                                    .ToListAsync();

        var z = unMappedResponse[0].Customer.FirtName;

        var m = _Mapper.Map<List<DtoOrderResponse>>(unMappedResponse);


        foreach (var unMappedOrder in unMappedResponse)
        {
            //         _httpClient.BaseAddress = new Uri($"https://sandbox.ecartpay.com/api/order/{unMappedOrder.ApiId}");
            //                 var responseApi = await _httpClient.PostAsync("orders" , null);
            // if (responseApi.IsSuccessStatusCode)
            // {
            //                 var responseApiSerialized = await responseApi.Content.ReadFromJsonAsync<DtoOrderResponse>();
            //                 response.MainResourceCollection.Prepend(responseApiSerialized);
            // }



        }

        

        return response;
    }

    public override async Task<AtlasMixedResponse<DtoOrderResponse>> Apply(DtoSharedApiEnvioOrdenRequest dto)
    {
        // dto.ApiCustomerId = Guid.NewGuid().ToString();
        // dto.ApiAcountId = Guid.NewGuid().ToString();

        // var maped =  _Mapper.Map<Order>( dto );

        // maped.ApiId = Guid.NewGuid().ToString();
        // maped.ApiNumber = Guid.NewGuid().ToString();    
        // maped.ApiStatus = "CREATED";
        // maped.ApiType = "ECOMMERCE";
        
        
        // repo.Insert(maped); 
        // UoW.SaveChanges();

        _httpClient.BaseAddress = new Uri("https://sandbox.ecartpay.com/api/");
        var mapped = _Mapper.Map<DtoApiECartOrderRequest>( dto);
        // mapped.shipping_address.state = new DtoApiECartEstadoRequest()
        // {
        //     code = "GTO",
   
        // };
        // mapped.shipping_address.country = new DtoApiECartPaisRequest()
        // {
        //     code = "MX",
        //     name = "Mexico"
        // };
        // mapped.shipping_address.address1 = "direccion de ejemplo #55 int. 2";
        var content = new StringContent( JsonSerializer.Serialize(mapped), Encoding.UTF8, "application/json" ); 
        


        var responseApi = await _httpClient.PostAsync("orders", content);

        if (responseApi.IsSuccessStatusCode)
        { 
            var responseApiSerialized = await responseApi.Content.ReadFromJsonAsync<DtoApiECartOrderResponse>();
            var mainResource = _Mapper.Map<DtoOrderResponse>(responseApiSerialized);
            string ApiCustomerId =Guid.NewGuid().ToString();

            var orderEntity = new Order()
            {
                ApiId = responseApiSerialized!.id,
                ApiStatus = responseApiSerialized.status,
                ApiNumber = responseApiSerialized.number,
                ApiType = responseApiSerialized.type,
                ApiAcountId = responseApiSerialized.account_id,
                ApiCustomerId = ApiCustomerId,
                Currency = responseApiSerialized.currency,
                ProductoOrder = dto.items.Select( x => new ProductoOrder()
                {
                   ProductoId= x.Id
                }).ToList(),

                Customer = new Customer()
                {
                    ApiCustomerId = ApiCustomerId,
                    FirtName = responseApiSerialized.first_name,
                    LastName = responseApiSerialized.last_name,
                    Email = responseApiSerialized.email,
                    Phone = mapped.phone,
                },

                Envios = new List<Envio>()
                {
                    new Envio()
                    {
                        Destino = new Destino()
                        {
                            Direccion = new Direccion()
                            {
                                City = responseApiSerialized.shipping_address.city,
                                CountryCode = responseApiSerialized.shipping_address.country.code,
                                CountryName = responseApiSerialized.shipping_address.country.name,
                                Email = responseApiSerialized.email,
                                // Phone = responseApiSerialized.shipping_address.phone,
                                Phone = mapped.phone,

                                StateCode = responseApiSerialized.shipping_address.state.code,
                                ZipCode = responseApiSerialized.shipping_address.postal_code,
                                InteriorNumber = dto.envios.First().Destino.interior_number_dest,
                                OutdoorNumber = dto.envios.First().Destino.outdoor_number_dest,
                                Neighborhood = dto.envios.First().Destino.neighborhood_dest,
                                References = dto.envios.First().Destino.references_dest,
                                Street = dto.envios.First().Destino.street_dest,
                                State = "GTO", //dto.envios.First().Destino.state_code_dest,
                                Name = dto.envios.First().Destino.name_dest,
                            }
                        }
                    }
                },
            };

            repo.Insert(orderEntity);
            UoW.SaveChanges();


            return await Task.FromResult(new AtlasMixedResponse<DtoOrderResponse>() { MainResource = mainResource });
        }
        
        throw new Exception("Error response is not ok");
    }
}
