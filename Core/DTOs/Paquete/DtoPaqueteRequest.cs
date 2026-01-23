using System;
using Core.DTOs.Base;

namespace Core.DTOs.Paquete;

public class DtoPaqueteRequest : AtlasBaseDto
{

    public string Type { get; set; } = null!;

    public string Depth { get; set; } = null!;
    public string Width { get; set; } = null!;
    public string Height { get; set; } = null!;
    public string Weight { get; set; } = null!;

    public string Description { get; set; } = null!;
}
