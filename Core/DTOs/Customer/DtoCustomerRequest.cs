using System;
using Core.DTOs.Base;

namespace Core.DTOs.Customer;

public class DtoCustomerRequest : AtlasBaseDto
{
    public string email { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string phone { get; set; } = null!;
}
