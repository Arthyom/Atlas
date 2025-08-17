using System;
using System.ComponentModel.DataAnnotations;
using Core.DTOs.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.DTOs.Categoria;

public class DtoCategoriaResponse : AtlasBaseDto
{
    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int ProductosAsociados { get; set; } = 0;
    
    [StringLength(200)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

}
