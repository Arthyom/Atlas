import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import { IDtoEcartShippingAddress } from "./APIs/Ecart/IDtoEcartShippingAddress";

export interface IDtoOrden{

   currency?: string;
       
         notifyUrl?: string;
       
         apiId?: string;
       
         apiAcountId?: string;
       
         apiCustomerId?: string;
       
         direccionId?: number;
       
         apiType?: string;
       
         apiNumber?: string;
       
         apiStatus?: string;
       
         envioId?: number;
       
         productos?: IDtoProducto[];
   
   
   
         selected? : boolean;
   
         folio?:string;
   
         email:string;
   
         state?:string;
   
         first_name?:string;
   
         phone:string;
   
         last_name?:string;

         shipping_address: IDtoEcartShippingAddress
}