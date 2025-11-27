import { ICartDireccion } from '@/Pages/Cart/interfaces/CartDireccion.interface';
import { useAtlasComposableMapKeyValue } from '../Composables/AtlasComposableMapKeyValue';
import { IAtlasCartPaymentForm } from '../Entities/IAtlasCartPaymentForm';
import { IAtlasDtoProducto } from '../Entities/IAtlasProducto';
import { IDtoApiItem } from '../Entities/IDtoApiItem';
import { IDtoApiOrders } from '../Entities/IDtoApiOrder';
import { IDtoApiShippingAddress } from '../Entities/IDtoApiShippingAddress';
export class AtlasHelperProducto{

    static getSelectedProducts( products: IAtlasDtoProducto[] ) {


       const allSelected =  products.filter( x => x.selected );

       const {mapToKeyValue} = useAtlasComposableMapKeyValue();

       return mapToKeyValue(allSelected, 'nombre')


    }

    static mapToApiItem(input:IAtlasDtoProducto) : IDtoApiItem {
        const outPut : IDtoApiItem = {
            name: input.nombre,
            quantity: input.cantidad,
            price: input.precioMayoreo,
            id: input.id
        }

        return outPut
    }

    static mapToDtoProducto( inputOnlyId : IDtoApiItem): IAtlasDtoProducto{
        return {
            cantidad: inputOnlyId.quantity,
            precioMayoreo: 0,
            precioUnitario: 0,
            categoria: '',
            descripcion: '',
            nombre: '',
            selected: false,
            id: inputOnlyId.id
        }
    }

    static mapToApiItems(input:IAtlasDtoProducto[] | undefined) : IDtoApiItem[] {
        if(!input)
            return []

        return input.map( this.mapToApiItem )
    }


     static mapToApiShippingAddress(input:ICartDireccion| undefined) : IDtoApiShippingAddress {
        if(!input)
            throw new Error("ICart Address cannot be null");
            

        const outPut : IDtoApiShippingAddress = {
            address1 : input.direccionPrimaria,
            address2:  input.direccionSecundaria,
            city: input.ciudad,
            postal_code: input.cp,
            country: {code: input.paisCode, name: input.paisName},
            state: {code: input.estado},
            first_name : input.first_name,
            last_name: input.last_name,
            phone: input.phone
        }

        return outPut

    }

    static mapToApiOrder (inputForm: IAtlasCartPaymentForm): IDtoApiOrders{

        inputForm.address!.first_name = `${inputForm.owner?.apellidoP} ${inputForm.owner?.apellidoM}`
        inputForm.address!.last_name = inputForm.owner?.nombre ||''
        inputForm.address!.phone = inputForm.owner?.telefono || ''

        const outPut: IDtoApiOrders ={
            currency : 'MXN',
            notify_url: '',
            email: inputForm.owner?.email || '',
            first_name: inputForm.owner?.nombre ||'',
            last_name: `${inputForm.owner?.apellidoP} ${inputForm.owner?.apellidoM}`,
            phone: inputForm.owner?.telefono || '',
            items: this.mapToApiItems(inputForm.productos),
            shipping_address: this.mapToApiShippingAddress( inputForm.address )
        }

        return outPut
    }
}