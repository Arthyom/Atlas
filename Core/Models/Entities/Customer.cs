using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities;

public class Customer: BaseEntity
{

    [StringLength(100)]
    [Unicode(false)]
    public string ApiCustomerId {get; set;} = null!;    
    
    public string Email { get; set; } = null!;

    public string FirtName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public string Phone { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
    
    // [InverseProperty("Curstomer")]
    // public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
