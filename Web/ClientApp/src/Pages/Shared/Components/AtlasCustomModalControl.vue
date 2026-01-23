<script setup lang="ts">
import { onBeforeMount, onMounted, onUpdated } from 'vue';
import { boolean } from 'yup';

  defineProps<{isValidOk?:boolean}>()

   onBeforeMount( ()=>{
      setTimeout(() => {
        const e = document.getElementById('1') as HTMLDialogElement
        e.showModal()
      }, 1000);
   })
</script>

<template>
  <!-- <button class="btn" onclick="my_modal_1.showModal()">open modal</button> -->
  <dialog id="1" class="modal">
    <div class="modal-box px-2">
      <h3 class="text-lg font-bold">
        <slot name="title">

        </slot>
      </h3>
      <p class="py-4">
        <slot name="body"></slot>
      </p>
      <div class="modal-action">
        <form method="dialog">
          <!-- if there is a button in form, it will close the modal -->
          <button class="btn" @click="$emit('close-modal', false)">Cancel</button>
           <button :disabled="!isValidOk" class="btn" @click="$emit('close-ok', true)">Ok</button>

        </form>
      </div>
    </div>
  </dialog>
</template>
