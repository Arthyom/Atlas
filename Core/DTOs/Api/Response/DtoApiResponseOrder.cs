using System;
using Atlas.Core.Entities;
using Core.DTOs.Base;
using Core.Models.Entities;

namespace Core.DTOs.Api.Response;

public class DtoApiResponseOrder 
{
    public string id { get; set; } = null!;

    public string pay_link { get; set; } = null!;

    public Customer Customer { get; set; } = null!;

    public Address Address { get; set; } = null!;

    public IEnumerable<Producto> Items { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public string ApiId { get; set; } = null!;

    public string ApiAcountId { get; set; } = null!;

    public string ApiCustomerId {get; set;} = null!;

    public string ApiType {get;set;} = null!;

    public string ApiNumber {get;set;} = null!;

    public string ApiStatus { get; set; } = null!;
}
