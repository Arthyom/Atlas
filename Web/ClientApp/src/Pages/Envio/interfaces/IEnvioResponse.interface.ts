import { IDestino } from "./IDestino";
import { IOrden } from "./IOrden";
import { IOrigen } from "./IOrigen";
import { IPaquete } from "./IPaquete";

export interface IEnvioResponse {
  deliveryType: string;

  atlasEnumShippingStatus: number;

  packageId: number;

  originId: number;

  destinationId: number;

  paquete: IPaquete;

  origen: IOrigen;

  destino: IDestino;

  order: IOrden;
}
