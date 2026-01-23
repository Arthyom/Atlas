using System;
using Core.DTOs.Base;

namespace Core.DTOs.Orden;

public class DtoApiEnPeShippingProviderResponse : AtlasBaseDto
{
    public string Title { get; set; } = null!;
    public DtoApiEnPeDeliveryTypeResponse DeliveryType { get; set; } = null!;
    public string PackageSize { get; set; } = null!;
    public double Cost { get; set; }
    public string Currency { get; set; } = null!;
    public bool Pickup { get; set; }
}
