using System;
using Core.DTOs.Base;
using Core.DTOs.Direccion;
using Core.DTOs.Paquete;
using Core.Enums;

namespace Core.DTOs.Envio;

public class DtoEnvioResponse : AtlasBaseDto
{
        public string DeliveryType { get; set; } = null!;

        public AtlasEnumShippingStatus Status { get; set; } 


        public  DtoPaqueteResponse packageSize { get; set; } = null!;


        public  DtoDireccionResponse Origin { get; set; } = null!;


        public  DtoDireccionResponse Destination { get; set; } = null!;


        public  DtoOrderResponse Order { get; set; } = null!;
}
