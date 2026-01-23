import { IDtoEnPeShippingPackageSize } from "./IDtoEnPehippingPackageSize";
import { IDtoEnPeShippingDestination } from "./IDtoEnPeShippingDestination";
import { IDtoEnPeShippingOrigin } from "./IDtoEnPeShippingOrigin";

export interface IDtoEnpeEnvioRequest {

    deliveryType?: string;

    status?: number;

    paquete?: IDtoEnPeShippingPackageSize;

    origen?: IDtoEnPeShippingOrigin;

    destino?: IDtoEnPeShippingDestination;

}