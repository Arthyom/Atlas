<script setup lang="ts">
    defineProps<{showNext?: boolean, showPrev?: boolean, showFinish?: boolean}>();
</script>


<template>

       <div class="flex w-full px-4 gap-2">
         
         <button v-if="showPrev" class="btn btn-danger flex-1" @click="$emit('swipe-prev')">
           Atras
          </button>
          
          <button v-if="showNext" class="btn btn-danger flex-1" @click="$emit('swipe-next')">
            Continuar
          </button>
          

              <button v-if="showFinish" class="btn btn-danger flex-1" @click="$emit('finishing')">
                Finalizar
              </button>
            </div>
</template>