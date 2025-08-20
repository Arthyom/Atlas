using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Core.Entities;

public partial class Categoria : BaseEntity
{
    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Color { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Categoria")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
