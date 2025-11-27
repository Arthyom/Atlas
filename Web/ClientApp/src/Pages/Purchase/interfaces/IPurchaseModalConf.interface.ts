import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { EnumPurchaseModalType } from "../Enums/ModalType.enum";
import { IDtoApiItem } from "@/Models/Entities/IDtoApiItem";

export interface IPurchaseModalConf{
    isVisible?: boolean;
    modalType?: EnumPurchaseModalType,
    items?: IDtoApiItem[],
    selected?: boolean
}