using System;
using Core.Models.Entities.Base;

namespace Core.Models.Entities;

public class Estado : BaseEntity
{
    public string code { get; set; }   = null!;
}
