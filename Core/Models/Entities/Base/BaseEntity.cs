using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities.Base;
[PrimaryKey("Id")]
public partial class BaseEntity
{
    [Key]
    public virtual int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    // public DateTime? DeletedAt {get;set;}
    
}


