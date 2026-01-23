import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useAtlasCartStore = defineStore('atlas-cart-store', () =>{

    const _product = ref<IDtoProducto[]>([])


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

    const addProduct = (newProduct: IDtoProducto) =>{
        
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

    const increase = (producto: IDtoProducto)=>{
        const prod = _product.value.find( x => x.id === producto.id ) 

        if(!prod)
            throw new Error("");
            

        if(prod.cantidad)
            prod.cantidad++
    }

    const decrease = (producto: IDtoProducto)=>{
        const prod = _product.value.find( x => x.id === producto.id ) 

        if(!prod)
            throw new Error("");
            
        if(prod.cantidad)
            prod.cantidad--   
    }

    const exclude = (producto: IDtoProducto) =>{
        const prod = _product.value.find( x => x.id === producto.id ) 

         if(!prod)
            throw new Error("");

        if(prod.cantidad)
            prod.selected = true
    }

    const restore = (producto: IDtoProducto) =>{
        const prod = _product.value.find( x => x.id === producto.id ) 

         if(!prod)
            throw new Error("");

        if(prod.cantidad)
            prod.selected = false
    }

    const popProduct = (product: IDtoProducto) =>{
        
    }


    const destroyCart = () =>{
        _product.value = []
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
        restore,
        destroyCart

    }
}) 