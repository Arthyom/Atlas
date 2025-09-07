<script setup lang="ts">
import IAtlasProducto from '@/Models/Entities/IAtlasProducto';
import Producto from '@/Models/Entities/IAtlasProducto';
import { atlasUseCartStore } from '@/Pages/Cart/store/cart.store';

const props = defineProps<IAtlasProducto>()

const { addProduct } = atlasUseCartStore()

</script>


<template>
    <div
          class="card bg-base-300 w-full shadow-sm flex justify-center"
          v-for="i in [1, 1, 1, 1]"
        >
          <figure>
            <div class="carousel w-full">
  <div id="slide1" class="carousel-item relative w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1625726411847-8cbb60cc71e6.webp"
      class="w-full" />
    <div class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between">
      <a href="#slide4" class="btn btn-circle">❮</a>
      <a href="#slide2" class="btn btn-circle">❯</a>
    </div>
  </div>
  <div id="slide2" class="carousel-item relative w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1609621838510-5ad474b7d25d.webp"
      class="w-full" />
    <div class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between">
      <a href="#slide1" class="btn btn-circle">❮</a>
      <a href="#slide3" class="btn btn-circle">❯</a>
    </div>
  </div>
  <div id="slide3" class="carousel-item relative w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1414694762283-acccc27bca85.webp"
      class="w-full" />
    <div class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between">
      <a href="#slide2" class="btn btn-circle">❮</a>
      <a href="#slide4" class="btn btn-circle">❯</a>
    </div>
  </div>
  <div id="slide4" class="carousel-item relative w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1665553365602-b2fb8e5d1707.webp"
      class="w-full" />
    <div class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between">
      <a href="#slide3" class="btn btn-circle">❮</a>
      <a href="#slide1" class="btn btn-circle">❯</a>
    </div>
  </div>
</div>

            
          </figure>

          <div class="card-body">
            
            <button  class="card-title text-primary hover:underline color-red-500">
              <Link href="/store/product?id=12">
              Card Title
              </Link>
            </button>
            <h1 class="font-bold text-info text-3xl hover:underline hover:cursor-pointer"  >
              {{ nombre }} (${{ precioUnitario }} - ${{precioMayore }}) 
            </h1>
            <p>
              {{ descripcion }}
            </p>

            <div class="avatar-group -space-x-6">
  <div class="avatar">
    <div class="w-12">
      <img src="https://img.daisyui.com/images/profile/demo/batperson@192.webp" />
    </div>
  </div>
  <div class="avatar">
    <div class="w-12">
      <img src="https://img.daisyui.com/images/profile/demo/spiderperson@192.webp" />
    </div>
  </div>
  <div class="avatar">
    <div class="w-12">
      <img src="https://img.daisyui.com/images/profile/demo/averagebulk@192.webp" />
    </div>
  </div>
  <div class="avatar avatar-placeholder">
    <div class="bg-neutral text-neutral-content w-12">
      <span>+99</span>
    </div>
  </div>
</div>


            <div class="card-actions justify-end">
              <button class="btn btn-primary" @click="addProduct({})">Buy Now</button>
            </div>
          </div>
        </div>
</template>