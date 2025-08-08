using System;
using Core.DTOs.Base;

namespace Core.DTOs;

public class DtoProductoBarCodeRequest : AtlasBaseDto
{
    public string  Nombre { get; set; } = null!;
}
