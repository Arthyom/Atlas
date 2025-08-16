using System;
using Core.DTOs.Base;

namespace Core.DTOs.Categoria;

public class DtoCategoriaRequest : AtlasBaseDto
{
    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Color { get; set; } = null!;      
}
