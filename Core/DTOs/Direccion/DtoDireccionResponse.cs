using System;
using Core.DTOs.Base;

namespace Core.DTOs.Direccion;

public class DtoDireccionResponse : AtlasBaseDto
{
    public string Company { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string? InteriorNumber { get; set; }
    public string OutdoorNumber { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Neighborhood { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public string References { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
