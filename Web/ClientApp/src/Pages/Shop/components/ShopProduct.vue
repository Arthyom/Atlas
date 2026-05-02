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
  class="card bg-white w-full shadow-lg flex justify-center mb-8"
    
  @mouseenter="isVisible = true"
  @mouseleave="isVisible = false"

  >
        <!-- <figure>
      <div class="carousel w-full">

        <div :id="imagen" class="carousel-item relative w-full" v-for="(imagen,i) in props.imagenes" :key="imagen">
          <img
            :src="getFileFrom('productoAnonimous','store', imagen)"
            class="min-h-60 max-h-60 w-full"
          />
          <div
            class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between"
          >
            <a :href="`#${getImageAt(props,i-1)}`" class="btn btn-circle">❮</a>
            <template v-if="getImageAt(props,i+1)">
                <a :href="`#${getImageAt(props,i+1)}`" class="btn btn-circle">❯</a>
            </template>
          </div>
        </div>

      </div>
    </figure> -->

    <figure >
            <template v-if="props.imagenes">
        <img
             :src="getFileFrom('productoAnonimous','store', props.imagenes[0])"
             class="min-h-60 max-h-60 w-full object-fill "
           />
            </template>
            <template v-else>
        <img
             :src="noFile()"
             class="min-h-60 max-h-60 w-full"
           />
            </template>
        </figure>


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
          bottom-18
           ">
           <div class="  w-full">
                    <div class="flex justify-center gap-2 p-2 bg-base-300 mx-18 rounded-lg">
              <button class="btn btn-circle "> 
                            <font-awesome-icon icon="fas fa-eye"></font-awesome-icon>
                        </button>
              <button class="btn btn-circle "> 
                            <font-awesome-icon icon="fas fa-dollar"></font-awesome-icon>
                        </button>
              <button class="btn btn-circle " @click="addProduct(props)">
                            <font-awesome-icon icon="fas fa-cart-arrow-down"></font-awesome-icon>
                        </button>
                    </div>
                </div>
            
            </div>
        </transition>

    <div class=" flex justify-center ">
       <img
             src="/logo.png"
             class="min-h-20 max-h-20 "
           />
        </div>
    

        <div class="card-body p-2 bg-white">
            <div class="flex flex-col text-center">
                <span class="text-base font-medium">{{ props.nombre }}</span>
                <span class="text-xl font-bold text-gray-600">${{ props.precioUnitario }}</span>
            </div>
            <!-- <button class="card-title text-primary hover:underline color-red-500">
        <Link href="/store/product?id=12"> Card Title </Link>
      </button>
      <h1
        class="font-bold text-info text-3xl hover:underline hover:cursor-pointer"
      >
        {{ nombre }} (${{ precioUnitario }} - ${{ precioMayore }})
      </h1>
      <p>
        {{ descripcion }}
      </p>

      <div class="card-actions justify-end">
        <button class="btn btn-primary" @click="({})">Buy Now</button>
      </div> -->
        </div>
    </div>
</template>
