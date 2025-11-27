import { computed, ref } from "vue"
import { router } from "@inertiajs/vue3";
import { useAtlasComposableLoadingCallbacks } from "./AtlasComposableLoadingCallbacks";
import { IAtlasDtoProducto } from "../Entities/IAtlasProducto";
import axios from "axios";
import  IAtlasMixedResponse from "../Interfaces/IAtlasMixedResponse";


export const useAtlasComposableAjaxActions = <TTipe>(resourcer: string, mode = 'admin', url: string | null) =>{

    const { opts } = useAtlasComposableLoadingCallbacks();

    const _state = ref<any>()

        const _states = ref<any[]>()

    const _resource = ref(resourcer);
    const _mode = ref(mode);

    const _url = computed( () => {

        if(url){
            return url
        }
        
        return `/${_mode.value}/${_resource.value}`
    })


    const getById = async(id:number)  =>{
        try {     
            const path = `${_url.value}/json/${id}`
    
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


    const getUrl = async<Tout>()  =>{
        try {     
            opts.onStart({})
            const response = await axios.get<Tout>(_url.value)
           await setTimeout(() => {
                
                opts.onFinish({})
            }, 2000);


            _state.value = response.data
    
            return response.data;
        } catch (error) {
            opts.onError({})
        }
    }

    const getState = computed( () => _state.value)
        const getStates = computed( () => _states.value)

    // getUrl<TTipe>()

    return{

        url,

        getState,
        getStates,
        getById,
        getUrl
    }
}