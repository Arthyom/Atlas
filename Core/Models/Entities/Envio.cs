using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;
using Core.Models.Entities.Base;

namespace Core.Models.Entities
{
    public class Envio : BaseEntity
    {
        public string? DeliveryType { get; set; }

        public AtlasEnumShippingStatus Status { get; set; } 

        public int? PackageId { get; set; }  

        public int? OriginId { get; set; }

        public int DestinationId {get; set; }

        public int? GuideId { get; set; }

        public string? ShippingProvider { get; set; }


        [ForeignKey("PackageId")]
        public virtual Paquete? Paquete { get; set; } = null!;


        [ForeignKey("OriginId")]
        public virtual Origen? Origen { get; set; } = null!;


        [ForeignKey("DestinationId")]
        public virtual Destino Destino { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;

        [ForeignKey("GuideId")]
        public virtual Guide? Guide {get; set;}
    }
}