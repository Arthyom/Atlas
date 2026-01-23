import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import { IDtoEcartCustomer } from "./IDtoEcartCustomer";
import { IDtoEnpeEnvioRequest } from "../EnPe/IDtoEnPeEnvioRequest";
import { IDtoProductoOrdenRequest } from "../../Orden.ts/IDtoProductoOrdenRequest";
import { IDtoEcartShippingAddress } from "./IDtoEcartShippingAddress";

export interface IDtoEcartOrder{
    currency: string;
    
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


      items: IDtoProductoOrdenRequest[];

      envios: IDtoEnpeEnvioRequest[];

      customer: IDtoEcartCustomer;

      shipping_address : IDtoEcartShippingAddress






      selected? : boolean;

      folio?:string;

      state?:string;
}