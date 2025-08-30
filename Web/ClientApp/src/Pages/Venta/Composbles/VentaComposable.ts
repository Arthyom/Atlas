import { computed, reactive, ref } from 'vue';
import { IAtlasDtoProducto } from '../../../Models/Entities/IAtlasProducto';

export const useVentaComposable = ( intialList: IAtlasDtoProducto[]) =>{

    const _productos = reactive<IAtlasDtoProducto[]>(intialList)

    const _total = ref(0)

    const _cantidad = ref(0)

    const _pago = ref(0)

    const _cambio = ref(0)

    const _metodoPago = ref('efectivo')

    const total = computed( () => {
        let total = 0;

        _productos.forEach( x =>{
            if( !x.selected ){
                total += x.cantidad * x.precioMayoreo
            }
        })

        _total.value = total
        return total;
    })

    const cantidad = computed( () =>{
        let cantidad = 0
        _productos.forEach( x => cantidad += !x.selected ? x.cantidad : 0)

        return cantidad
    })

    const increaseAmount = (producto: IAtlasDtoProducto) =>{
        producto.cantidad++;
    }

    const reduceAmount = (producto: IAtlasDtoProducto) =>{
        producto.cantidad--;
    }

    const toggleProduct = (producto: IAtlasDtoProducto) =>{
        producto.selected = !producto.selected
    }

    const productos = computed( () =>[..._productos])

    const addNewProduct = (newItem: IAtlasDtoProducto) =>{
        
        const product = _productos.find( x => x.id === newItem.id )

        if(!!product){
            product.cantidad++
            return;
        }
        
        newItem.cantidad = 0;
        newItem.cantidad++;
        _productos.push(newItem)
    }

    const setPago = (pago: number) =>{
        _pago.value=pago;
    }

    const setCambio = (cambio: number) =>{
        _cambio.value = cambio
    }


    const cambio = computed( () =>  {
        const cambio = _pago.value > 0 && _pago.value >= _total.value ? _pago.value - _total.value : 0
        _cambio.value = cambio;

        return cambio;
    })

    const metodoPago = computed ( () => _metodoPago.value)

    const isValidPayment = computed (  ()=> _total.value <= _pago.value  &&  0 < _pago.value )

    const getDetails = ()=>{
        return {
            pago: _pago.value,
            metodoPago: _metodoPago.value,
            cambio: _cambio.value,
            productos:  _productos,
            total: _total.value
        }
    }



    return{


        total,
        productos,
        cantidad,
        cambio,
        metodoPago,
        isValidPayment,


        reduceAmount,
        increaseAmount,
        toggleProduct,
        addNewProduct,
        setPago,
        setCambio,
        getDetails

    }
}