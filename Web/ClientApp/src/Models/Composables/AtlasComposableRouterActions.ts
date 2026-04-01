import { computed, ref } from "vue"
import { router } from "@inertiajs/vue3";
import { useAtlasComposableLoadingCallbacks } from "./AtlasComposableLoadingCallbacks";
import axios from "axios";
import  IAtlasMixedResponse from "../Interfaces/IAtlasMixedResponse";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";


export const useAtlasComposableRouterHtmlActions = () => {
  const { opts } = useAtlasComposableLoadingCallbacks();

  const getHtml = async (url: string) => {
    try {
      opts.onStart({});
        await router.get(url);
     await setTimeout(() => {
                
                opts.onFinish({})
            }, 2000);
    } catch (error) {
      opts.onError({});
    }
  };
  return {
    getHtml
  };
};