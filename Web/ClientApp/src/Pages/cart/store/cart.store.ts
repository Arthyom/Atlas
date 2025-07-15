import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const atlasUseCartStore = defineStore('cart-store', () =>{

    const _product = ref<any[]>([])


    const products = computed( () => [..._product.value] )
    const length = computed ( () => _product.value.length )

    const addProduct = (newProduct: any) =>{
        _product.value.push(products)
    }

    const popProduct = (product: any) =>{
        
    }

    return {

        products,
        length,
        addProduct,
        popProduct

    }
}) 