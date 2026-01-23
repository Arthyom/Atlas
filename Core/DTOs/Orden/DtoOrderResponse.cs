using System;
using Atlas.Core.Entities;
using Core.DTOs.Base;
using Core.DTOs.Customer;
using Core.DTOs.Direccion;
using Core.DTOs.Envio;
using Core.Models.Entities;

namespace Core.DTOs;

public class DtoOrderResponse : AtlasBaseDto
{
    public string folio { get; set; } = null!;
    
    public string pay_link { get; set; } = null!;

    public DtoCustomerResponse Customer { get; set; } = null!;

    // public Address Address { get; set; } = null!;
 
    public IEnumerable<DtoProductoResponse> Productos { get; set; } = null!;

    public IEnumerable<DtoEnvioResponse> Envios { get; set; } = null!;


    public DtoDireccionResponse Direccion {get; set;} = null!;

    public string Currency { get; set; } = null!;

    public string Status {get;set;} = null!;




    public string ApiId { get; set; } = null!;

    public string ApiAcountId { get; set; } = null!;

    public string ApiCustomerId {get; set;} = null!;

    public string ApiType {get;set;} = null!;

    public string ApiNumber {get;set;} = null!;

    public string ApiStatus { get; set; } = null!;

}
