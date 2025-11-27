using System;

namespace Core.DTOs;

public class DtoApiRequestItem
{
    public string name { get; set; } = null!;

    public int quantity { get; set; } 

    public double price { get; set; }
}
