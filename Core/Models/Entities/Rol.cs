using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

[Table("Rol")]
public partial class Rol : BaseEntity
{ 
    [StringLength(200)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [InverseProperty("Rol")]
    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();

    [InverseProperty("Rol")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
