using System;
using Atlas.Core.Entities;
using Core.DTOs.Base;
using Core.DTOs.Customer;
using Core.DTOs.Item;
using Core.DTOs.Orden;
using Core.Enums;
using Core.Models.Entities;

namespace Core.DTOs.Api.Response;

public class DtoApiECartOrderResponse 
{
    public string id { get; set; } = null!;

    public string pay_link { get; set; } = null!;

    public DtoCustomerResponse Customer { get; set; } = null!;

    public DtoApiECartAddressResponse Address { get; set; } = null!;

    public IEnumerable<DtoProductoResponse> Productos { get; set; } = null!;



    // public string Currency { get; set; } = null!;

    public string Folio {get;set;} = null!;

    // public string Status {get;set;} = null!;




    public string ApiId { get; set; } = null!;

    public string ApiAcountId { get; set; } = null!;

    public string ApiCustomerId {get; set;} = null!;

    public string ApiType {get;set;} = null!;

    public string ApiNumber {get;set;} = null!;

    public string ApiStatus { get; set; } = null!;





    public string account_id { get; set; } = null!;

    public string type { get; set; } = null!;

    public string number { get; set; } = null!;

    public string status { get; set; }  = null!;



    public string email { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string last_name { get; set; }   = null!;

    public string phone { get; set; } = null!;

    public string currency  { get; set; } = null!;

    public string country { get; set; } = null!;



    public DtoApiEcartOrderTotalResponse totals  { get; set; } = null!;

    public DtoApiECartItemResponse [] items = null!;

    public DtoApiECartAddressResponse shipping_address { get; set; } = null!;
}
