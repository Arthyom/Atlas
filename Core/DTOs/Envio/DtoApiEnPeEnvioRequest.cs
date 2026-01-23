using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Api.Response;
using Core.DTOs.Base;
using Core.DTOs.Direccion.Destino;
using Core.DTOs.Direccion.Origen;
using Core.DTOs.Paquete;
using Core.Enums;

namespace Core.DTOs.Envio
{
    public class DtoApiEnPeEnvioRequest : AtlasBaseDto
    {
        public string? DeliveryType { get; set; }

        public AtlasEnumShippingStatus? Status { get; set; } 

        public int PackageId { get; set; }  

        public int OriginId { get; set; }

        public int DestinationId {get; set; }


        public  DtoPaqueteRequest Paquete { get; set; } = null!;


        public  DtoApiEnPeOrigenRequest Origen { get; set; } = null!;


        public  DtoApiEnPeDestinoRequest Destino { get; set; } = null!;

        public  DtoApiECartOrderResponse Orden { get; set; } = null!;

        public string Folio { get; set; }   = null!;

        public string State { get; set; }   = null!;

    }
}