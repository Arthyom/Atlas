using System;
using Core.DTOs.Base;

namespace Core.DTOs;

public class DtoItem : AtlasBaseDto
{
    public string name { get; set; } = null!;

    public int quantity { get; set; } 

    public double price { get; set; }
}
