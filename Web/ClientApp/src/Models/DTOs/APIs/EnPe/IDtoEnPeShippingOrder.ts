import { IDtoEnPeShippingPackageSize } from "./IDtoEnPehippingPackageSize";
import { IDtoEnPeShippingDestination } from "./IDtoEnPeShippingDestination";
import { IDtoEnPeShippingOrigin } from "./IDtoEnPeShippingOrigin";

export interface IDtoEnPeShippingOrder {
  status: number;
  deliveryType?: string;
  packageSize?: IDtoEnPeShippingPackageSize;
  origin: IDtoEnPeShippingOrigin;
  destination: IDtoEnPeShippingDestination;
}

