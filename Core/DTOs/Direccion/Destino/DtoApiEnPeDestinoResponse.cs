using System;
using Core.DTOs.Base;

namespace Core.DTOs.Direccion.Destino;

public class DtoApiEnPeDestinoResponse : AtlasBaseDto
{
    public string company_dest { get; set; } = null!;
    public string street_dest { get; set; } = null!; 
    public string? interior_number_dest { get; set; } 
    public string outdoor_number_dest { get; set; } = null!;
    public string zip_code_dest { get; set; }= null!;
    public string neighborhood_dest { get; set; }= null!;
    public string city_dest { get; set; }= null!;
    public string state_dest { get; set; }= null!;
    public string references_dest { get; set; }= null!;
    public string name_dest { get; set; }= null!;
    public string email_dest { get; set; }= null!;
    public string phone_dest { get; set; }= null!;
    public string save_dest { get; set; }= null!;
}
