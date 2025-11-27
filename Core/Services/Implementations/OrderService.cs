using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
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
                                    .ToListAsync();

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
