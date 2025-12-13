using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Api.Response;
using Core.DTOs.Base;
using Core.Models.Entities;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Services.Implementations;

public class OrderService : AtlasBaseServiceMixed<Order, DtoOrder, DtoOrderResponse>, IOrderService
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
                                    .Include(o => o.Direccion)
                                    .Include(o => o.Envios)
                                    .Include(o => o.Productos)
                                    
                                    .ToListAsync();

        var z = unMappedResponse[0].Customer.FirtName;

        var m = _Mapper.Map<List<DtoApiRequestOrder>>(unMappedResponse);

        Customer c1 = new Customer()
        {
        
            ApiCustomerId = "1M6j3K2eZvKYlo2C",
            FirtName = "John Doe",
            Email = "",
            LastName="aaa",
            Phone = "555-1234",
            CreatedAt = DateTime.UtcNow
        };

        Direccion d1 = new Direccion()
        {
            City = "New York",
            Company = "Company Inc.",
            CountryCode = "US",
            CountryName = "United States",
            Email = "",
            InteriorNumber = "Apt 1",
            Name = "John Doe",
            Neighborhood = "Manhattan",
            OutdoorNumber = "123",
            Phone = "555-1234",
            References = "Near Central Park",
            State = "NY",
            StateCode = "NY",   
            Street = "5th Avenue",
            ZipCode = "10001" ,

        };

        Producto p1 = new Producto()
        {
            CategoriaId = 2,
            Nombre = "Product 1",
            Descripcion = "Description 1",
            PrecioMayoreo = 19.99M,

          
        };

        Envio e1 = new Envio()
        {
            CreatedAt = DateTime.UtcNow,
            DeliveryType = "standard",
            Status = Core.Enums.AtlasEnumShippingStatus.Created,
            DestinationId = 1,
            OriginId = 1,
            PackageId = 1,
            Destino = new Destino()
            {
                Direccion = d1,
                DireccionId = d1.Id,
                CreatedAt = DateTime.UtcNow
            },
            Origen = new Origen()
            {
                Direccion = d1,
                DireccionId = d1.Id,
                CreatedAt = DateTime.UtcNow
            },
            Paquete = new Paquete()
            { 
                Weight = "2.4",
                Height = "10",
                Width = "15",
                Depth = "20",
                Description = "Package Description",
                CreatedAt = DateTime.UtcNow,
                Type = "box"
            },
        };

        Order o1 = new Order()
        {
            ApiAcountId = "1M6j3K2eZvKYlo2C",
            ApiCustomerId = "NL6g9bX5pX5b8D",
            ApiId = "NL6h1cX5pX5b8E",
            ApiNumber = "1001",
            ApiStatus = "pending",
            ApiType = "standard",
            Currency = "USD",
            DireccionId = 1,
            CreatedAt = DateTime.UtcNow,
            Customer = c1,
            Direccion = e1.Destino.Direccion,
            Productos = new List<Producto>() { p1 },
            Envios = new List<Envio>() { e1 }
        };

        repo.Insert(o1);
        UoW.SaveChanges();

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

    public override async Task<AtlasMixedResponse<DtoOrderResponse>> Apply(DtoOrder dto)
    {
        _httpClient.BaseAddress = new Uri("https://sandbox.ecartpay.com/api/");
        var mapped = _Mapper.Map<DtoApiRequestOrder>(dto);
        var content = new StringContent( JsonSerializer.Serialize(mapped), Encoding.UTF8, "application/json" ); 
        


        var responseApi = await _httpClient.PostAsync("orders", content);

        if (responseApi.IsSuccessStatusCode)
        { 
            var responseApiSerialized = await responseApi.Content.ReadFromJsonAsync<DtoApiResponseOrder>();
            var mainResource = _Mapper.Map<DtoOrderResponse>(responseApiSerialized);
            return await Task.FromResult(new AtlasMixedResponse<DtoOrderResponse>() { MainResource = mainResource });
        }
        
        throw new Exception("Error response is not ok");
    }
}
