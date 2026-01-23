using System;
using Core.DTOs.Base;

namespace Core.DTOs.Item;

 public class DtoApiECartItemResponse : AtlasBaseDto 
{
    public string name { get; set; } = null!;

    public double quantity { get; set; } 

    public double price { get; set; }

     public double discount { get; set; } 

    public double total { get; set; } 

    public double tax { get; set; }


    public bool is_service { get; set; } 

    public string[] taxes { get; set; } = null!;    
}
