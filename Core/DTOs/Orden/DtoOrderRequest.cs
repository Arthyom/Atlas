using System;
using Core.DTOs.Base;
using Core.Models.Entities;

namespace Core.DTOs;
 
public class DtoOrderRequest : AtlasBaseDto
{
    // public string customer_id { get; set; } = null!;

    public string currency { get; set; } = null!;

    public string email { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string phone { get; set; } = null!;


    public DtoApiECartAddressRequest shipping_address{get; set; } = null!;


    public IEnumerable<DtoItem> items { get; set; } = null!;

    
}
