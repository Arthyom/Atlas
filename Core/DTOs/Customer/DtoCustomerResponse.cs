using System;
using Core.DTOs.Base;

namespace Core.DTOs.Customer;

public class DtoCustomerResponse : AtlasBaseDto
{

    public string ApiCustomerId = null!;
    public string Email = null!;
    public string FirtName = null!;
    public string LastName= null!;
    public string Phone= null!;
}
