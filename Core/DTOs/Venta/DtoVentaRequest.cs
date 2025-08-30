using System;
using Core.DTOs.Base;

namespace Core.DTOs.Venta;

public class DtoVentaRequest : AtlasBaseDto
{
    public decimal Total { get; set; }

    public decimal Cambio { get; set; }
    
    public decimal Pago { get; set; }

    public List<DtoKeyValue> Productos { get; set; } = new List<DtoKeyValue>();
}
