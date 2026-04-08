using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Atlas.Core.Entities;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities;

public class Modelo : BaseEntity{

    
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

    public int ProductoId { get; set; }


    public byte ExistenciaMinima { get; set; }

    public byte ExistenciaMaxima { get; set; }


    public virtual Producto? Producto { get; set; }

    public virtual ICollection<ImagenModelo> ImagenModelos { get; set; } = new List<ImagenModelo>();
    

}
