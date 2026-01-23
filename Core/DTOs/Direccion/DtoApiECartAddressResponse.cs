using System;
using Core.DTOs.Base;

namespace Core.DTOs;

public class DtoApiECartAddressResponse : AtlasBaseDto
{
    public string address1 { get; set; } = null!;
    public string address2 { get; set; } = null!;

    public string city { get; set; } = null!;
    public string first_name { get; set; } = null!;
    public string last_name { get; set; } = null!;

    public string phone { get; set; } = null!;
    public string postal_code { get; set; } = null!;


    public DtoApiECartPaisRequest country { get; set; } = null!;
    
    public DtoApiECartEstadoRequest state { get; set; } = null!;
}
