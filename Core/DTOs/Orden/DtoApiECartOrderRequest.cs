using System;

namespace Core.DTOs;

public class DtoApiECartOrderRequest
{
    //  public string customer_id { get; set; } = null!;

    public string currency { get; set; } = null!;

    public string email { get; set; } = null!;

    public string first_name { get; set; } = null!;

    // public string folio { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string phone { get; set; } = null!;

    public DtoApiECartAddressRequest  shipping_address{get; set; } = null!;

    public IEnumerable<DtoApiECartItemRequest> items { get; set; } = null!;
}
