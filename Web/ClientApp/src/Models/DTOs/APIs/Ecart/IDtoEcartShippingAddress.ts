import { IDtoEcartCountry } from "./IDtoEcartCountry";
import { IDtoECartDireccion } from "./IDtoEcartState";

export interface IDtoEcartShippingAddress{
    address1: string,
    address2: string,
    city: string,
    first_name: string,
    last_name: string,
    phone: string,
    postal_code: number,
    country: IDtoEcartCountry,
    state: IDtoECartDireccion
}