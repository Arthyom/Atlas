import { ICartDireccion, ICartMetodoPago, ICartPropietario } from "@/Pages/Cart/interfaces/CartDireccion.interface";
import { IDtoProducto } from "../../../../Pages/Producto/DTOs/IDtoProducto";

export interface IDtoPaymentForm{

  address?: ICartDireccion;
  payMethod?: ICartMetodoPago;
  owner?: ICartPropietario,
  productos?: IDtoProducto[],
  totalProductos?: number,
  totalPago?: number
  
}