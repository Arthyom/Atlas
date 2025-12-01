

export interface IApiEPShippingRate {
  title: string;
  deliveryType: IApiEPDeliveryType;
  packageSize: number | string;
  cost: number;
  currency: string;
  pickup: boolean;
}

export interface IApiEPDeliveryType {
  name: string;
  feature: string;
  description: string;
  company: string;
}