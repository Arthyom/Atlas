using System;
using Core.DTOs.Base;

namespace Core.DTOs.Modelo;

public class DtoModeloResponse : AtlasBaseDto
{

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public decimal PrecioMayoreo { get; set; }

    public byte Existencia { get; set; }

    public string? Talla { get; set; }

    public string? Color { get; set; }

    public string? Genero { get; set; }
 
    public string? Slug { get; set; }

    public int ProductoId { get; set; }

    public byte ExistenciaMinima { get; set; }

    public byte ExistenciaMaxima { get; set; }


    public IEnumerable<string>? imagenes { get; set; }

}
