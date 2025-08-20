using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.Base;

namespace Core.Models.Entities;

public partial class Venta : BaseEntity
{
    [Column(TypeName = "decimal(38, 0)")]
    public decimal Total { get; set; }

    [Column(TypeName = "decimal(38, 0)")]
    public decimal Cambio { get; set; }

    [InverseProperty("Venta")]
    public virtual ICollection<ProductoVenta> ProductoVenta { get; set; } = new List<ProductoVenta>();
}
