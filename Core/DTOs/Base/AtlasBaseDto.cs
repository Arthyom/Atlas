using System;
using System.ComponentModel.DataAnnotations;
using Core.Models.Entities.Base;

namespace Core.DTOs.Base;

public class AtlasBaseDto
{
    [Key]
    public virtual int Id { get; set; }
}
