using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Atlas.Core.Entities;
using Core.Models.Entities.Base;

namespace Core.Models.Entities;

public partial class ProductoVenta : BaseEntity
{
    public int ProductoId { get; set; }

    public int VentaId { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("ProductoVenta")]
    public virtual Producto Producto { get; set; } = null!;

    [ForeignKey("VentaId")]
    [InverseProperty("ProductoVenta")]
    public virtual Venta Venta { get; set; } = null!;
}
