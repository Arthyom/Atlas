<script setup lang="ts">
import { DialogHTMLAttributes, onBeforeMount, onMounted, onUpdated, useTemplateRef } from 'vue';
import { useAtlasStoreLoading } from '../store/AtlasStoreLoading';


const modal = useTemplateRef<HTMLDialogElement>('modalRef')

const vs = useAtlasStoreLoading()
onUpdated ( () =>{
  if(vs.isVisible)
    modal.value?.showModal()
})


</script>

<template >
    <dialog id="my_modal_2" class="modal" ref="modalRef" v-if="vs.isVisible">
      <div class="modal-box">
        <h3 class="text-lg font-bold">Hello!</h3>
        <span class="loading loading-spinner loading-xl"></span>
      </div>
    </dialog>
</template>
