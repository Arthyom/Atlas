using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

[Table("Usuario")]
public partial class Usuario : BaseEntity
{
    [StringLength(200)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public int RolId { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Rol Rol { get; set; } = null!;
}
