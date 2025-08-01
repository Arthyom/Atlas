using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

[Table("Imagen")]
public partial class Imagen : BaseEntity
{
    [StringLength(200)]
    [Unicode(false)]
    public string Identificador { get; set; } = null!;

    // [MaxLength(1)]
    public byte[] Info { get; set; } = null!;

    [InverseProperty("Imagen")]
    public virtual ICollection<ImagenProducto> ImagenProductos { get; set; } = new List<ImagenProducto>();
}
