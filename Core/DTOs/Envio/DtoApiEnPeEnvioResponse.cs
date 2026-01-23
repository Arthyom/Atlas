using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Api.Response;
using Core.DTOs.Base;
using Core.DTOs.Direccion.Destino;
using Core.DTOs.Direccion.Origen;
using Core.Enums;
using Core.Models.Entities;

namespace Core.DTOs.Envio
{
    public class DtoApiEnPeEnvioResponse : AtlasBaseDto
    {

         public string DeliveryType { get; set; } = null!;

        public AtlasEnumShippingStatus Status { get; set; } 

        public int PackageId { get; set; }  

        public int OriginId { get; set; }

        public int DestinationId {get; set; }


        public  Models.Entities.Paquete PackageSize { get; set; } = null!;


        public  DtoApiEnPeOrigenResponse Origin { get; set; } = null!;


        public  DtoApiEnPeDestinoResponse Destination { get; set; } = null!;

        public  DtoApiECartOrderResponse Order { get; set; } = null!;

        // public string Folio { get; set; }   = null!;

        // public string State { get; set; }   = null!;

        
    }
}