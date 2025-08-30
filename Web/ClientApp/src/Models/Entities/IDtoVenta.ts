import { IAtlasKeyValue } from '../Interfaces/IAtlasKeyValue';
import { IAtlasBaseEntity } from './BaseEntity/IAtlasBaseEntity';
import { IAtlasDtoProducto } from './IAtlasProducto';
export interface IDtoVenta extends IAtlasBaseEntity {

    total: number;

    cambio: number;

    pago: number;

    folio:string;

    totalProductos: number;

    productos: IAtlasKeyValue []

}
