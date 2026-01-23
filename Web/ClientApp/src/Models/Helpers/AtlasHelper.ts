import { ICartDireccion } from '@/Pages/Cart/interfaces/CartDireccion.interface';
import { useAtlasComposableMapKeyValue } from '../Composables/AtlasComposableMapKeyValue';
import { IDtoApiItem } from '../../Pages/Producto/DTOs/IDtoApiItem';
// import { IDtoApiOrder } from '../../Pages/Shop/pages/IDtoOrder';
import { IDtoProducto } from '@/Pages/Producto/DTOs/IDtoProducto';
import { IDtoEcartShippingAddress } from '../DTOs/APIs/Ecart/IDtoEcartShippingAddress';
import { IDtoPaymentForm } from '../DTOs/APIs/Ecart/IDtoECartPaymentForm';
import { IDtoEcartOrder } from '../DTOs/APIs/Ecart/IDtoEcartOrder';
import { IDtoEcartCustomer } from '../DTOs/APIs/Ecart/IDtoEcartCustomer';
import { IDtoEnpeEnvioRequest } from '../DTOs/APIs/EnPe/IDtoEnPeEnvioRequest';
import { IDtoProductoOrdenRequest } from '../DTOs/Orden.ts/IDtoProductoOrdenRequest';
export class AtlasHelperProducto{

    static mapToCustomer( input: IDtoPaymentForm) : IDtoEcartCustomer{
        return{
            email: input.owner?.email || '',
            first_name: input.owner?.nombre || '',
            last_name: `${input.owner?.apellidoP} ${input.owner?.apellidoM}`,
            phone: input.owner?.telefono || ''
        }
    }

    static getSelectedProducts( products: IDtoProducto[] ) {


       const allSelected =  products.filter( x => x.selected );

       const {mapToKeyValue} = useAtlasComposableMapKeyValue();

       return mapToKeyValue(allSelected, 'nombre')


    }

    static mapToApiItem(input:IDtoProducto) : IDtoApiItem {
        const outPut : IDtoApiItem = {
            name: input.nombre,
            quantity: input.cantidad,
            price: input.precioMayoreo,
            id: input.id
        }

        return outPut
    }

    static mapToDtoProducto( inputOnlyId : IDtoApiItem): IDtoProducto{
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

    static mapToApiItems(input:IDtoProducto[] | undefined) : IDtoApiItem[] {
        if(!input)
            return []

        return input.map( this.mapToApiItem )
    }

    static mapToApiProdcuts(input: IDtoPaymentForm) : IDtoProductoOrdenRequest[] {
        if(!input.productos)
            return []

        input.productos.forEach( p => p.imagenes = undefined );

        return input.productos
    }




     static mapToApiShippingAddress(input:ICartDireccion| undefined) : IDtoEcartShippingAddress {
        if(!input)
            throw new Error("ICart Address cannot be null");
            
        const intNum = `Int. ${input.numeroInterior}`

        const outPut : IDtoEcartShippingAddress = {
            address1 : `${input.calle} #${input.numeroExterior} ${intNum}`,
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

    static mapToApiEnvios(input: IDtoPaymentForm) : IDtoEnpeEnvioRequest[] {
        return [
            {
                destino:{

                    company_dest: "",
                    street_dest: input.address?.direccionPrimaria || "",
                    interior_number_dest: input.address?.numeroExterior.toString() || "" ,
                    outdoor_number_dest: input.address?.numeroInterior.toString() || "" ,
                    zip_code_dest: input.address?.cp.toString() || "" ,
                    neighborhood_dest: input.address?.colonia || "",
                    city_dest: input.address?.ciudad|| "" ,
                    state_dest: input.address?.estado || "MX" ,
                    references_dest: input.address?.referencias || "" ,
                    name_dest: "",
                    email_dest: "",
                    phone_dest: input.address?.phone || "",
                    save_dest: "true",
                    ocurre : "false"
                },
                
            }
        ]
    }

    static mapToApiOrder (inputForm: IDtoPaymentForm): IDtoEcartOrder{

        inputForm.owner!.apellidoM = `${inputForm.owner?.apellidoP} ${inputForm.owner?.apellidoM}`
        inputForm.owner!.apellidoP = inputForm.owner?.nombre ||''
        inputForm.owner!.telefono = inputForm.owner?.telefono || ''
        // inputForm.address!.direccion1 = `${inputForm.owner?.direccion}`;
        // inputForm.address!.estado = "Guanajuato";
        // inputForm.address!.estadoCodigo = "GTO";
        // inputForm.address!.pais = 'Mexico';
        // inputForm.address!.paisCode = 'MX';
        // inputForm.address!.paisCodigo = 'MX'

        const outPut: IDtoEcartOrder ={
            currency : 'MXN',
            customer: this.mapToCustomer(inputForm),
            items: this.mapToApiProdcuts(inputForm),
            envios : this.mapToApiEnvios(inputForm),

            // notify_url: '',
            // email: inputForm.owner?.email || '',
            // first_name: inputForm.owner?.nombre ||'',
            // last_name: `${inputForm.owner?.apellidoP} ${inputForm.owner?.apellidoM}`,
            // phone: inputForm.owner?.telefono || '',
            // items: this.mapToApiItems(inputForm.productos),
            shipping_address: this.mapToApiShippingAddress( inputForm.address )
        }

        return outPut
    }
}