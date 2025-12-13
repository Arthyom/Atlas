using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;
using Core.Enums;
using Core.Models.Entities;

namespace Core.DTOs.Envio
{
    public class DtoApiResponseEnvio : AtlasBaseDto
    {

         public string DeliveryType { get; set; } = null!;

        public AtlasEnumShippingStatus Status { get; set; } 

        public int PackageId { get; set; }  

        public int OriginId { get; set; }

        public int DestinationId {get; set; }


        public  Paquete Paquete { get; set; } = null!;


        public  Origen Origen { get; set; } = null!;


        public  Destino Destino { get; set; } = null!;

        public  Order Orden { get; set; } = null!;

        public string Folio { get; set; }   = null!;

        public string State { get; set; }   = null!;

        
    }
}