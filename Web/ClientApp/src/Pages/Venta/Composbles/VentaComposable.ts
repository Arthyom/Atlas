import { computed, reactive, ref } from 'vue';
import { IAtlasDtoProducto } from '../../../Models/Entities/IAtlasProducto';

export const useVentaComposable = ( intialList: IAtlasDtoProducto[]) =>{

    const _productos = reactive<IAtlasDtoProducto[]>(intialList)

    const _total = ref(0)

    const _cantidad = ref(0)

    const total = computed( () => {
        let total = 0;

        _productos.forEach( x =>{
            if( !x.selected ){
                total += x.cantidad * x.precioMayoreo
            }
        })

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


    return{


        total,
        productos,
        cantidad,

        reduceAmount,
        increaseAmount,
        toggleProduct,
        addNewProduct

    }
}