using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

[Table("Producto")]
public partial class Producto : BaseEntity
{

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "decimal(38, 0)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(38, 0)")]
    public decimal PrecioMayoreo { get; set; }

    public byte Existencia { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Talla { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Color { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Genero { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Slug { get; set; }

    public byte ExistenciaMinima { get; set; }

    public byte ExistenciaMaxima { get; set; }

    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("Productos")]
    public virtual Categoria Categoria { get; set; } = null!;

    [InverseProperty("Producto")]
    public virtual ICollection<ImagenProducto> ImagenProductos { get; set; } = new List<ImagenProducto>();
    
    [InverseProperty("Producto")]
    public virtual ICollection<ProductoVenta> ProductoVenta { get; set; } = new List<ProductoVenta>();
}
