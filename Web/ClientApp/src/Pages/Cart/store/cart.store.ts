import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useCartStore = defineStore('cart-store', () =>{

    const _product = ref<IAtlasDtoProducto[]>([])


    const products = computed( () => _product.value )
    const length = computed ( () => _product.value.length )
    const totalPago = computed( ( ) =>{
        let total = 0

        _product.value.forEach( x => {
            if(!x.selected)
                total += x.cantidad * x.precioUnitario;
        })

        return total;
    })

    const totalProductos = computed(() => {
        let total = 0;
        _product.value.forEach( x => total +=  x.cantidad || 0)

        return total;
    })

    const addProduct = (newProduct: IAtlasDtoProducto) =>{
        
        const isIn = _product.value.find( x => x.id === newProduct.id);

        if(isIn)
            isIn.cantidad++
        else
        {
           const obCopy = {...newProduct}
            
            obCopy.cantidad=1
            _product.value.push(obCopy)
        }
    }

    const increase = (producto: IAtlasDtoProducto)=>{
        const prod = _product.value.find( x => x.id === producto.id ) 

        if(!prod)
            throw new Error("");
            

        if(prod.cantidad)
            prod.cantidad++
    }

    const decrease = (producto: IAtlasDtoProducto)=>{
        const prod = _product.value.find( x => x.id === producto.id ) 

        if(!prod)
            throw new Error("");
            
        if(prod.cantidad)
            prod.cantidad--   
    }

    const exclude = (producto: IAtlasDtoProducto) =>{
        const prod = _product.value.find( x => x.id === producto.id ) 

         if(!prod)
            throw new Error("");

        if(prod.cantidad)
            prod.selected = true
    }

    const restore = (producto: IAtlasDtoProducto) =>{
        const prod = _product.value.find( x => x.id === producto.id ) 

         if(!prod)
            throw new Error("");

        if(prod.cantidad)
            prod.selected = false
    }

    const popProduct = (product: IAtlasDtoProducto) =>{
        
    }

    return {

        products,
        length,
        totalProductos,
        totalPago,

        addProduct,
        popProduct,
        increase,
        decrease,
        exclude,
        restore

    }
}) 