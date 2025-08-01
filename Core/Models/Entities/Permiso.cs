using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

[Table("Permiso")]
public partial class Permiso : BaseEntity
{
    [StringLength(200)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [InverseProperty("Permiso")]
    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
}
