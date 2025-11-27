import { IDtoApiCountry } from "./IDtoApiCountry";
import { IDtoApiState } from "./IDtoApiState";

export interface IDtoApiShippingAddress{
    address1: string,
    address2: string,
    city: string,
    first_name: string,
    last_name: string,
    phone: string,
    postal_code: number,
    country: IDtoApiCountry,
    state: IDtoApiState
}