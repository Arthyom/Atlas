import { IDtoEnPeShippingPackageSize } from "@/Models/DTOs/APIs/EnPe/IDtoEnPehippingPackageSize";
import { IDtoEnPeShippingOrigin } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingOrigin";
import { IDtoEnPeShippingDestination } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingDestination";
import { IDtoOrder } from "@/Pages/Shop/pages/IDtoOrder";


export interface IDtoEnvio {
  deliveryType: string;

  status: number;

  state: string;

  selected: boolean;
  // currency: string;

  // folio:number;

  // packageId: number;

  // originId: number;

  // destinationId: number;

  packageSize: IDtoEnPeShippingPackageSize;

  origin: IDtoEnPeShippingOrigin;

  destination: IDtoEnPeShippingDestination;

  order: IDtoOrder;
}
