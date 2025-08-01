using System;
using System.ComponentModel.DataAnnotations;
using Core.DTOs.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.DTOs;

public class DtoCategoriaResponse : AtlasBaseDto
{

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;
}
