<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import  { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import { useAtlasCartStore } from "@/Pages/Shared/store/AtlasCartStore";
import { ref } from "vue";

const props = defineProps<IDtoProducto>();

const {noFile, getFirstFileForProducto, getFileFrom, getImageAt, getLastImage} = useAtlasComposableUseFilesFetcher()
const { length, addProduct } = useAtlasCartStore()
const isVisible = ref(false)
</script>

<template>

  <div 
  class="card  w-full shadow-sm flex justify-center  bg-white"
    
  @mouseenter="isVisible = true"
  @mouseleave="isVisible = false"

  >
 

    <figure class="0">
      <div v-if="props.imagenes">
        <img
             :src="getFileFrom('productoAnonimous','store', props.imagenes[0])"
             class="min-h-40 max-h-40   object-fill w-full "
           />
          </div>
          <div v-else>
            <img
            :src="noFile()"
            class="min-h-30 max-h-30 w-full"
            />
          </div>
        </figure>
        <div class=" flex justify-center ">
          <img
             src="/logo.png"
             class="min-h-10 max-h-10 "
          />
        </div>


    <transition
      enter-active-class="transition-opacity duration-300 ease-out"
      leave-active-class="transition-opacity duration-300 ease-in"
      enter-from-class="opacity-0"
      enter-to-class="opacity-100"
      leave-from-class="opacity-100"
      leave-to-class="opacity-0"
    >
        <div v-show="isVisible"
          class="
          w-full
          absolute
          bottom-14
           ">
           <div class="  w-full">
            <div class="flex justify-center gap-1  bg-black p-1 mx-5 rounded-md">
              <button class="btn btn-sm btn-black btn-circle "> 
                <font-awesome-icon icon="fas fa-eye"></font-awesome-icon>
              </button>
              <button class="btn btn-sm btn-circle "> 
                <font-awesome-icon icon="fas fa-dollar"></font-awesome-icon>
              </button>
              <button class="btn btn-sm btn-circle " @click="addProduct(props)">
                <font-awesome-icon icon="fas fa-car"></font-awesome-icon>
              </button>
            </div>
          </div>
            
        </div>
        </transition>

    

    <div class="card-body px-2 py-0 pb-2 bg-white">
        <div class="flex flex-col text-center">
          <span class=" text-lg font-extralight">{{ props.nombre }}</span> 
          <span class="text-md font-bold">{{ props.precioUnitario }}</span>
        </div>
    </div>
  </div>
</template>
