<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import IAtlasProducto, { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import { useAtlasCartStore } from "@/Pages/Shared/store/AtlasCartStore";

const props = defineProps<IAtlasDtoProducto>();

const {getFirstFileForProducto, getFileFrom, getImageAt, getLastImage} = useAtlasComposableUseFilesFetcher()
const { length, addProduct } = useAtlasCartStore()
</script>

<template>

  <div class="card bg-base-300 w-full shadow-sm flex justify-center">
    <figure>
      <div class="carousel w-full">

        <div :id="imagen" class="carousel-item relative w-full" v-for="(imagen,i) in props.imagenes" :key="imagen">
          <img
            :src="getFileFrom('producto','store', imagen)"
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
    </figure>

    <div class="card-body p-2 ">
        <div class="grid grid-cols-3  xl:grid-cols-5 content-start bg-red-300 m">
            <div class="col-span-2  md:justify-center xl:col-span-4">
             <span class=" text-2xl font-bold">{{ props.nombre }}</span> 
            </div>
            <div class="flex flex-col justify-center items-end  bg-red-700">
              <span class="text-2xl font-bold">{{ props.precioUnitario }}</span>
            </div>
            <div class="col-span-3 xl:col-span-5 grid grid-cols-3 w-full justify-items-center md:place-self-center bg-blue-500 gap-4">
                <button class="btn btn-circle btn-secondary"> 
                  <font-awesome-icon icon="fas fa-eye"></font-awesome-icon>
                </button>
                <button class="btn btn-circle btn-primary"> 
                  <font-awesome-icon icon="fas fa-dollar"></font-awesome-icon>
                </button>
                <button class="btn btn-circle btn-accent" @click="addProduct(props)">
                  <font-awesome-icon icon="fas fa-car"></font-awesome-icon>
                </button>
            </div>



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
