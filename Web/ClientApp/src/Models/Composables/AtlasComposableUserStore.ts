import { IDtoUsuarioResponse } from "@/Pages/auth/DTOs/IDtoUsuario";
import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useAtlasComposableUserStore = defineStore("UserStore", ()=>{

    const _userInfo = ref<IDtoUsuarioResponse>()

    const setUserInfo = ( userInfo: IDtoUsuarioResponse) =>{
        _userInfo.value = userInfo;
    }

    const userInfo = computed( () => _userInfo.value);

    return {

        userInfo,
        setUserInfo
    }
})