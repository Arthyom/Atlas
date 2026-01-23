using System;
using Core.DTOs.Base;

namespace Core.DTOs.Direccion.Origen;

public class DtoApiEnPeOrigenResponse : AtlasBaseDto
{
    public string company_origin { get; set; } = null!;
    public string street_origin { get; set; } = null!; 
    public string? interior_number_origin { get; set; } 
    public string outdoor_number_origin { get; set; } = null!;
    public string zip_code_origin { get; set; }= null!;
    public string neighborhood_origin { get; set; }= null!;
    public string city_origin { get; set; }= null!;
    public string state_origin { get; set; }= null!;
    public string references_origin { get; set; }= null!;
    public string name_origin { get; set; }= null!;
    public string email_origin { get; set; }= null!;
    public string phone_origin { get; set; }= null!;
    public string save_origin { get; set; }= null!;
}
