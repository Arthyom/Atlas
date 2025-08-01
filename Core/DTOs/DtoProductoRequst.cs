using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.DTOs.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.DTOs;

public class DtoProductoRequst : AtlasBaseDto
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

    public byte ExistenciaMinima { get; set; }

    public byte ExistenciaMaxima { get; set; }

    public int CategoriaId { get; set; }

    public IFormCollection? imagenes {get; set; }
}
