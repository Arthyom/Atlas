using System;

namespace Core.Models.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    
    public string Email { get; set; } = null!;

    public string FirtName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public string Phone { get; set; } = null!;
}
