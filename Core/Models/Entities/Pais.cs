using System;
using Core.Models.Entities.Base;

namespace Core.Models.Entities;

public class Pais : BaseEntity
{
    public string code { get; set; } = null!;
    public string name { get; set; }    = null!;

}
