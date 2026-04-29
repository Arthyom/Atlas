using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities
{
    public class Etiqueta : BaseEntity
    {
        

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;



    [StringLength(1000)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "decimal(38, 0)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(38, 0)")]
    public decimal PrecioMayoreo { get; set; }

    public byte Existencia { get; set; }


    public byte ExistenciaMinima { get; set; }

    public byte ExistenciaMaxima { get; set; }


    public int ModeloId { get; set; }


    public Modelo? Modelo { get; set; }

    public int? EtiquetaId { get; set; }

    public List< Etiqueta>? EtiquetasRelacionadas { get; set; } = new List<Etiqueta>();


    }
}