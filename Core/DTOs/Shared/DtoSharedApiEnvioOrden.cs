using System;
using Core.DTOs.Base;
using Core.DTOs.Customer;
using Core.DTOs.Envio;

namespace Core.DTOs.Shared;

public class DtoSharedApiEnvioOrdenRequest : AtlasBaseDto
{

    public string  folio { get; set; }  = null!;
     public string Currency { get; set; } = null!;

    // public string email { get; set; } = null!;

    // public string first_name { get; set; } = null!;

    // public string last_name { get; set; } = null!;

    // public string phone { get; set; } = null!;

    public DtoCustomerRequest Customer { get; set; } = null!;


    public DtoApiECartAddressRequest shipping_address{get; set; } = null!;

    public IEnumerable<DtoProductoRequst> items { get; set; } = null!;

    public IEnumerable<DtoApiEnPeEnvioRequest>? envios { get; set; } = null!;



    public string ApiId { get; set; } = null!;

    public string ApiAcountId { get; set; } = null!;

    public string ApiCustomerId {get; set;} = null!;

    public string ApiType {get;set;} = null!;

    public string ApiNumber {get;set;} = null!;

    public string ApiStatus { get; set; } = null!;


}
