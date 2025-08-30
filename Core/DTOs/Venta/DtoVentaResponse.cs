using System;
using Core.DTOs.Base;

namespace Core.DTOs.Venta;

public class DtoVentaResponse : AtlasBaseDto
{
    public decimal Total { get; set; }

    public decimal Cambio { get; set; }

    public decimal Pago { get; set; }

    public int TotalProductos { get; set; }

    public string Folio { get; set;} = null!;
    
    public List<DtoKeyValue> Productos { get; set; } = new List<DtoKeyValue>();
}
