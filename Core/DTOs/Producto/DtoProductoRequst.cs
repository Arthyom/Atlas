using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.DTOs.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.DTOs;

public class DtoProductoRequst : AtlasBaseDto
{

    // [StringLength(100)]
    // [Unicode(false)]
    public string Nombre { get; set; } = null!;

 
    public string Descripcion { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public decimal PrecioMayoreo { get; set; }

    public byte Existencia { get; set; }


    public string? Talla { get; set; }


    public string? Color { get; set; }

    public string? Genero { get; set; }

    public string? Slug { get; set; }

    public byte ExistenciaMinima { get; set; }

    public byte ExistenciaMaxima { get; set; }

    public int CategoriaId { get; set; }

    public IFormCollection? imagenes {get; set; }
}
