using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

[Table("RolPermiso")]
public partial class RolPermiso : BaseEntity
{
        public int RolId { get; set; }

    public int PermisoId { get; set; }

    [ForeignKey("PermisoId")]
    [InverseProperty("RolPermisos")]
    public virtual Permiso Permiso { get; set; } = null!;

    [ForeignKey("RolId")]
    [InverseProperty("RolPermisos")]
    public virtual Rol Rol { get; set; } = null!;
}
