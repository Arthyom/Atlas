import { IDtoApiItem } from "./IDtoApiItem";
import { IDtoApiShippingAddress } from "./IDtoApiShippingAddress";

export interface IDtoApiOrders{
    shipping_address : IDtoApiShippingAddress,
    currency: string,
    email: string,
    first_name: string,
    last_name: string,
    notify_url: string,
    phone: string,
    items: IDtoApiItem[],
    folio?: string,
    state?: string,
    selected?: boolean
}