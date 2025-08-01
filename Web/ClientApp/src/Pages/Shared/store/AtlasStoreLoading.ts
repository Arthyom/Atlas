import { defineStore } from "pinia";
import { computed, ref } from "vue";

export const useAtlasStoreLoading = defineStore('atlasStoreLoading', () =>{

    const _isModalVisible = ref(false);

    const isVisible = computed ( () => _isModalVisible.value);

    const setVisibleStatus = (status: boolean) =>{
        _isModalVisible.value = status
    }


    return{
        isVisible,
        setVisibleStatus
    }
});