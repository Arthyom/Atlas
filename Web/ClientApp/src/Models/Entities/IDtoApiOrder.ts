import { IAtlasDtoProducto } from "./IAtlasProducto";
import { IDtoApiItem } from "./IDtoApiItem";
import { IDtoApiShippingAddress } from "./IDtoApiShippingAddress";

export interface IDtoApiOrders{
    currency: string;
    
      notifyUrl: string;
    
      apiId: string;
    
      apiAcountId: string;
    
      apiCustomerId: string;
    
      direccionId: number;
    
      apiType: string;
    
      apiNumber: string;
    
      apiStatus: string;
    
      envioId: number;
    
      productos: IAtlasDtoProducto[];



      selected? : boolean;

      folio?:string;

      state?:string;
}