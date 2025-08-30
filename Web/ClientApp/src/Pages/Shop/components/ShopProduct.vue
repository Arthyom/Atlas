<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import IAtlasProducto, { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";

const props = defineProps<IAtlasDtoProducto>();

const {getFirstFileForProducto, getFileFrom, getImageAt, getLastImage} = useAtlasComposableUseFilesFetcher()
</script>

<template>

  <div class="card bg-base-300 w-full shadow-sm flex justify-center">
    <figure>
      <div class="carousel w-full">

        <div :id="imagen" class="carousel-item relative w-full" v-for="(imagen,i) in props.imagenes" :key="imagen">
          <img
            :src="getFileFrom('producto','store', imagen)"
            class="w-full"
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

        <div id="slide2" class="carousel-item relative w-full">
          <img
            src="https://img.daisyui.com/images/stock/photo-1609621838510-5ad474b7d25d.webp"
            class="w-full"
          />
          <div
            class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between"
          >
            <a href="#slide1" class="btn btn-circle">❮</a>
            <a href="#slide3" class="btn btn-circle">❯</a>
          </div>
        </div>

        <div id="slide3" class="carousel-item relative w-full">
          <img
            src="https://img.daisyui.com/images/stock/photo-1414694762283-acccc27bca85.webp"
            class="w-full"
          />
          <div
            class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between"
          >
            <a href="#slide2" class="btn btn-circle">❮</a>
            <a href="#slide4" class="btn btn-circle">❯</a>
          </div>
        </div>

        <div id="slide4" class="carousel-item relative w-full">
          <img
            src="https://img.daisyui.com/images/stock/photo-1665553365602-b2fb8e5d1707.webp"
            class="w-full"
          />
          <div
            class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between"
          >
            <a href="#slide3" class="btn btn-circle">❮</a>
            <a href="#slide1" class="btn btn-circle">❯</a>
          </div>
        </div>

      </div>
    </figure>

    <div class="card-body">
        <div class="grid grid-cols-3">
            <div>{{ props.nombre }}</div>
            <div>{{ props.precioUnitario }}</div>
            <div>
                <button class="btn btn-circle"> S</button>
                 <button class="btn btn-circle"> x</button>
            </div>

            <div class="col-span-3">Lorem ipsum dolor sit amet consectetur adipisicing elit. Ea harum laborum fuga unde! Porro placeat modi pariatur saepe tempore laudantium natus, deserunt quae qui mollitia, fugiat voluptate voluptas facilis ab.</div>

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
