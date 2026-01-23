import { IDtoEnPeDireccion } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeDireccion";
import { IDtoApiItem } from "../../Producto/DTOs/IDtoApiItem";
import { IDtoProducto } from "../../Producto/DTOs/IDtoProducto";
import { IDtoEnPeShippingOrder } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingOrder";
import { IDtoEnPeShippingPackageSize } from "@/Models/DTOs/APIs/EnPe/IDtoEnPehippingPackageSize";
import { IDtoEnPeShippingOrigin } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingOrigin";
import { IDtoEnPeShippingDestination } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingDestination";
import { EnumStateOrden } from "../Enums/StatesOrder.enum";
import { IDtoGuiaResponse } from "@/Pages/Envio/interfaces/IDtoGuiaResponse";

export interface IDtoOrder{

      deliveryType: string;

      status: EnumStateOrden;

      packageSize: IDtoEnPeShippingPackageSize;

      origin: IDtoEnPeShippingOrigin;

      destination: IDtoEnPeShippingDestination
  
      // currency?: string;
  
      // folio?:string;
      
      // state?:string;

      // status?:string;


      // notifyUrl?: string;
    
      // apiId?: string;
    
      // apiAcountId?: string;
    
      // apiCustomerId?: string;
    
      // direccionId?: number;
    
      // apiType?: string;
    
      // apiNumber?: string;
    
      // apiStatus?: string;
    
      // envioId?: number;
    
     
      
      // direccion?: IDtoEnPeDireccion;
      
      // envios: IDtoEnPeShippingOrder
      
      
      
      selected? : boolean;
      
      productos?: IDtoProducto[];

      currency: string;

      folio:number;

      pdf: IDtoGuiaResponse;



      // email:string;

      // first_name?:string;

      // phone:string;

      // last_name?:string;
}