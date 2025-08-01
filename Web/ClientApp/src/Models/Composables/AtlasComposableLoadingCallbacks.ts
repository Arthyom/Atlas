import { useAtlasStoreLoading } from "@/Pages/Shared/store/AtlasStoreLoading"
import { storeToRefs } from "pinia"

export const useAtlasComposableLoadingCallbacks = () =>{
    
    const { isVisible, setVisibleStatus } =  useAtlasStoreLoading() 

    const onSucces = (data: any) =>{
        setVisibleStatus(false)
    }

    const onStart = (data:any) =>{
        setVisibleStatus(true)
    }

    const onError = (data:any) =>{
        setVisibleStatus(false)
    }

    const onFinish = (data: any) =>{
        setVisibleStatus(false)
    }

    const opts = {
        onSucces,
        onStart,
        onError,
        onFinish
    }

    return{
        opts
    }
}