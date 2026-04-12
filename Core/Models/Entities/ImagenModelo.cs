using System;
using System.ComponentModel.DataAnnotations.Schema;
using Atlas.Core.Entities;
using Core.Models.Entities.Base;

namespace Core.Models.Entities;

public partial class ImagenModelo : BaseEntity
{
    public int ImagenId { get; set; }

    public int ModeloId  { get; set; }

    // [ForeignKey("ImagenId")]
    // [InverseProperty("ImagenProductos")]
    public virtual Imagen Imagen { get; set; } = null!;

    // [ForeignKey("ProductoId")]
    // [InverseProperty("Modelo")]
    public virtual Modelo Modelo { get; set; } = null!;
}