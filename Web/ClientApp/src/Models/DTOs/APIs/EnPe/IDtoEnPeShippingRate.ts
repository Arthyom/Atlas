import { IDtoEnPeDeliveryType } from "./IDtoEnPeDeliveryType";

export interface IDtoEnPeShippingRate {
  title: string;
  deliveryType: IDtoEnPeDeliveryType;
  packageSize: number | string;
  cost: number;
  currency: string;
  pickup: boolean;
}

