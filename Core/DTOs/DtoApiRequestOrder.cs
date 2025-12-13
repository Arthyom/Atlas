using System;

namespace Core.DTOs;

public class DtoApiRequestOrder
{
    //  public string customer_id { get; set; } = null!;

    public string currency { get; set; } = null!;

    public string email { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string folio { get; set; } = null!;

    public DtoApiRequestAddress shipping_address{get; set; } = null!;

    public IEnumerable<DtoApiRequestItem> items { get; set; } = null!;
}
