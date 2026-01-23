import { IAtlasKeyValue } from '../../../Models/Interfaces/IAtlasKeyValue';
import { IAtlasBaseEntity } from '../../../Models/DTOs/BaseEntity/IAtlasBaseEntity';

export interface IDtoVenta extends IAtlasBaseEntity {

    total: number;

    cambio: number;

    pago: number;

    folio:string;

    totalProductos: number;

    productos: IAtlasKeyValue []

}
