import { ICartDireccion, ICartMetodoPago, ICartPropietario } from "@/Pages/Cart/interfaces/CartDireccion.interface";
import { IAtlasDtoProducto } from "./IAtlasProducto";

export interface IAtlasCartPaymentForm{

  address?: ICartDireccion;
  payMethod?: ICartMetodoPago;
  owner?: ICartPropietario,
  productos?: IAtlasDtoProducto[],
  totalProductos?: number,
  totalPago?: number
  
}