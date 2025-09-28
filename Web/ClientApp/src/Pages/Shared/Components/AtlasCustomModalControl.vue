<script setup lang="ts">
import { onMounted, onUpdated } from 'vue';


   onMounted( ()=>{
       const e = document.getElementById('my_modal_1') as HTMLDialogElement
       e.showModal()
   })
</script>

<template>
  <!-- <button class="btn" onclick="my_modal_1.showModal()">open modal</button> -->
  <dialog id="my_modal_1" class="modal">
    <div class="modal-box">
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
           <button class="btn" @click="$emit('close-ok', true)">Ok</button>

        </form>
      </div>
    </div>
  </dialog>
</template>
