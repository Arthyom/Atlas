<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { ref } from "vue";

defineProps<IAtlasDtoProducto>();
const { getFileFrom } = useAtlasComposableUseFilesFetcher()
const mode = ref('admin')
const resource = ref('producto')
</script>

<template>

  <template v-if="imagenes?.length">
    <div class="flex justify-center">

      <div class="avatar-group -space-x-6 ">
  
        <div class="avatar border-neutral-300" v-for="imagen in imagenes.slice(1,4)">
          <div class="w-20">
            <img
              :src="getFileFrom(resource,mode,imagen)"
            />
          </div>
        </div>
       
        <div class="avatar avatar-placeholder" v-if="imagenes.length >= 5">
          <div class="bg-neutral text-neutral-content w-20">
            <span>{{ imagenes.length -4 }}</span>
          </div>
        </div>
        
        <template v-if="imagenes.length == 1">
    <div class="avatar-group space-x-6  flex justify-center">
      <div class="avatar avatar-placeholder border-neutral-300">
          <div class="bg-neutral text-neutral-content w-20">
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
          <div class="bg-neutral text-neutral-content w-20">
            <span>0</span>
          </div>
      </div>
    </div>
  </template>

</template>
