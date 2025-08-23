import { computed, ref } from "vue"
import { router } from "@inertiajs/vue3";
import { useAtlasComposableLoadingCallbacks } from "./AtlasComposableLoadingCallbacks";
import { IAtlasDtoProducto } from "../Entities/IAtlasProducto";
import axios from "axios";
import  IAtlasMixedResponse from "../Interfaces/IAtlasMixedResponse";


export const useAtlasComposableAjaxActions = (resourcer: string, mode = 'admin') =>{

    const { opts } = useAtlasComposableLoadingCallbacks();

    const _resource = ref(resourcer);
    const _mode = ref(mode);

    const url = computed( () => `/${_mode.value}/${_resource.value}`)


    const getById = async(id:number)  =>{
        try {     
            const path = `${url.value}/json/${id}`
    
            opts.onStart({})
            const response = await axios.get<IAtlasMixedResponse<IAtlasDtoProducto>>(path)
           await setTimeout(() => {
                
                opts.onFinish({})
            }, 2000);
    
           
            return response.data.mainResource
        } catch (error) {
            opts.onError({})
        }
    }

    return{

        url,
        getById
    }
}