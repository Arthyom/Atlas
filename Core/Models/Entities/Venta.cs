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

    public int TotalProductos { get; set; }

    [Column(TypeName = "decimal(38, 0)")]
    public decimal Pago { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string Folio { get; set; } = null!;

    [InverseProperty("Venta")]
    public virtual ICollection<ProductoVenta> ProductoVenta { get; set; } = new List<ProductoVenta>();
}
