<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import { ref } from "vue";

defineProps<IDtoProducto>();
const { getFileFrom } = useAtlasComposableUseFilesFetcher()
const mode = ref('admin')
const resource = ref('productoAnonimous')
</script>

<template>

  <template v-if="imagenes?.length">
    <div class="flex justify-center">

      <div class="avatar-group -space-x-6 ">
  
        <div class="avatar border-neutral-300" v-for="imagen in imagenes.slice(1,4)">
          <div class="w-15 md:w-20 lg:w-30">
            <img
              :src="getFileFrom(resource,mode,imagen)"
            />
          </div>
        </div>
       
        <div class="avatar avatar-placeholder" v-if="imagenes.length >= 5">
          <div class="bg-neutral text-neutral-content w-15 md:w-20 lg:w-30">
            <span>{{ imagenes.length -4 }}</span>
          </div>
        </div>
        
        <template v-if="imagenes.length == 1">
    <div class="avatar-group space-x-6  flex justify-center">
      <div class="avatar avatar-placeholder border-neutral-300">
          <div class="bg-neutral text-neutral-content w-15 md:w-20 lg:w-30">
            <span>0</span>
          </div>
      </div>
    </div>
    </template>
      </div>
    </div>
  </template>
  <template v-else>
    <div class="avatar-group space-x-6  flex justify-center">
      <div class="avatar avatar-placeholder border-neutral-300">
          <div class="bg-neutral text-neutral-content w-30">
            <span>0</span>
          </div>
      </div>
    </div>
  </template>

</template>
