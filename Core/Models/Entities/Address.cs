using System;

namespace Core.Models.Entities;

public class Address
{
    public string address1 { get; set; } = null!;
    public string address2 { get; set; } = null!;

    public string city { get; set; } = null!;
    public string first_name { get; set; } = null!;
    public string last_name { get; set; } = null!;

    public string phone { get; set; } = null!;
    public string postal_code { get; set; } = null!;


    public Pais country { get; set; } = null!;
    
    public Estado state { get; set; } = null!;

    

}
