import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";

export interface IOrden {
  currency: string;

  notifyUrl: string;

  apiId: string;

  apiAcountId: string;

  apiCustomerId: string;

  direccionId: number;

  apiType: string;

  apiNumber: string;

  apiStatus: string;

  envioId: number;

  productos: IAtlasDtoProducto[];
}
