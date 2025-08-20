using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

[Table("ImagenProducto")]
public partial class ImagenProducto : BaseEntity
{
    public int ImagenId { get; set; }

    public int ProductoId { get; set; }

    [ForeignKey("ImagenId")]
    [InverseProperty("ImagenProductos")]
    public virtual Imagen Imagen { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("ImagenProductos")]
    public virtual Producto Producto { get; set; } = null!;
}
