using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities;

public class Direccion : BaseEntity
{
    public string Company { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string? InteriorNumber { get; set; } 
    public string OutdoorNumber { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Neighborhood { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State{ get; set; } = null!;

    public string StateCode{ get; set; } = null!;

    public string CountryCode{ get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public string References{ get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
