using System;
using Core.DTOs.Base;

namespace Core.DTOs.Direccion.Destino;

public class DtoApiEnPeDestinoRequest : AtlasBaseDto
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

    public string country_code_dest { get; set; }= null!;

    public string country_code_name { get; set; }= null!;

    public string state_code_dest { get; set; }= null!;



    // public string Company { get; set; } = null!;
    // public string Street { get; set; } = null!;
    // public string? InteriorNumber { get; set; } 
    // public string OutdoorNumber { get; set; } = null!;
    // public string ZipCode { get; set; } = null!;
    // public string Neighborhood { get; set; } = null!;
    // public string City { get; set; } = null!;
    // public string State{ get; set; } = null!;

    // public string StateCode{ get; set; } = null!;

    // public string CountryCode{ get; set; } = null!;

    // public string CountryName { get; set; } = null!;

    // public string References{ get; set; } = null!;
    // public string Name { get; set; } = null!;
    // public string Email { get; set; } = null!;
    // public string Phone { get; set; } = null!;

}
