using System;
using Core.DTOs.Base;

namespace Core.DTOs.Orden;

public class DtoApiEnPeDeliveryTypeResponse : AtlasBaseDto
{
 public string Name { get; set; } = null!;
        public string Feature { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Company { get; set; } = null!;
}
