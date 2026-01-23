import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import { EnumPurchaseModalType } from "../Enums/ModalType.enum";
import { IDtoApiItem } from "@/Pages/Producto/DTOs/IDtoApiItem";

export interface IPurchaseModalConf{
    isVisible?: boolean;
    modalType?: EnumPurchaseModalType,
    items?: IDtoApiItem[],
    productos?: IDtoProducto[],
    selected?: boolean
}