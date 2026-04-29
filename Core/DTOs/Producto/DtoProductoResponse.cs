using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.DTOs.Base;
using Core.DTOs.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Core.DTOs;


public class DtoProductoResponse : AtlasBaseDto
{

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public decimal PrecioMayoreo { get; set; }

    public byte Existencia { get; set; }


    public string? Talla { get; set; }


    public string? Color { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Genero { get; set; }

    public string? Slug { get; set; }

    public byte ExistenciaMinima { get; set; }

    public byte ExistenciaMaxima { get; set; }

    public int CategoriaId { get; set; }
    
    public string Categoria{ get; set; } = null!;

    public string CategoriaColor{ get; set; } = null!;

    // public string? Etiquetas{ get; set; }

    public int Cantidad {get;set;} 



    public IEnumerable<string>? imagenes { get; set; }

    public IEnumerable<DtoModeloResponse>? modelos { get; set; }
}
