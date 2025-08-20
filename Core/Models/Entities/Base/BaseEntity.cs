using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Entities.Base;

public partial class BaseEntity 
{
    [Key]
    public virtual int Id { get; set; }

    public DateTime CreatedAt {get;set;}
    
    public DateTime? UpdatedAt { get; set; }
    // public DateTime? DeletedAt {get;set;}

}


