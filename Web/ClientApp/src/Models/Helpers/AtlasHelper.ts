import { useAtlasComposableMapKeyValue } from '../Composables/AtlasComposableMapKeyValue';
import { IAtlasDtoProducto } from '../Entities/IAtlasProducto';
export class AtlasHelperProducto{

    static getSelectedProducts( products: IAtlasDtoProducto[] ) {


       const allSelected =  products.filter( x => x.selected );

       const {mapToKeyValue} = useAtlasComposableMapKeyValue();

       return mapToKeyValue(allSelected, 'nombre')


    }
}