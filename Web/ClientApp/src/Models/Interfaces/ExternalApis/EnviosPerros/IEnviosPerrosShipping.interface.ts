
export interface IApiEPShippingOrder {
  deliveryType?: string;
  packageSize?: IApiEPShippingPackageSize;
  origin?: IApiEPShippingOrigin;
  destination?: IApiEPShippingDestination;
}

export interface IApiEPShippingDestination {
  company_dest: string;
  street_dest: string;
  interior_number_dest: string;
  outdoor_number_dest: string;
  zip_code_dest: string;
  neighborhood_dest: string;
  city_dest: string;
  state_dest: string;
  references_dest: string;
  name_dest: string;
  email_dest: string;
  phone_dest: string;
  save_dest: string;
  ocurre: string;
}

export interface IApiEPShippingOrigin {
  company_origin: string;
  street_origin: string;
  interior_number_origin: string;
  outdoor_number_origin: string;
  zip_code_origin: string;
  neighborhood_origin: string;
  city_origin: string;
  state_origin: string;
  references_origin: string;
  name_origin: string;
  email_origin: string;
  phone_origin: string;
  save_origin: string;
}

export interface IApiEPShippingPackageSize {
  type: string;
  depth: string;
  width: string;
  height: string;
  weight: string;
  description: string;
}