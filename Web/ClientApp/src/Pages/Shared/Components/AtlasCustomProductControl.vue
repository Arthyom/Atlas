<script setup lang="ts">
import { IAtlasDtoProducto } from '@/Models/Entities/IAtlasProducto';
import { useAtlasCartStore } from '../store/AtlasCartStore';
import { useAtlasComposableUseFilesFetcher } from '@/Models/Composables/AtlasComposableFilesFetcher';


const producto = defineProps<IAtlasDtoProducto>()

const {increase, decrease, exclude,restore} = useAtlasCartStore()
const {getFirstFileForProducto} = useAtlasComposableUseFilesFetcher()
</script>

<template>
  <div class="flex shadow-md border-1 border-base-300 rounded-md mb-2">
    <div class="flex flex-col items-center justify-center p-2 pt-1 pr-0 pb-1">
      <div class="relative w-full">
        <div class="absolute z-10">
          <button
            class="btn btn-sm md:btn-sm lg:btn-md btn-base-100 btn-circle items-center"
          >
            {{ producto.cantidad }}
          </button>
        </div>

        <div class="avatar-group w-full">
          <div class="avatar">
            <div class="w-15 md:w-30 lg:w-42">
              <img :src="getFirstFileForProducto(producto)" class="" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="flex flex-col justify-center px-2 w-full">
      <div class="text-md font-bold">
        {{ producto.nombre }}
      </div>

      <div class="" v-if="!producto.selected">
        <button
          class="btn btn-xs btn-circle btn-ghost"
          @click="increase(producto)"
        >
          <font-awesome-icon icon="fas fa-plus"></font-awesome-icon>
        </button>
        <button
          class="btn btn-xs btn-circle btn-ghost"
          @click="decrease(producto)"
        >
          <font-awesome-icon icon="fas fa-minus"></font-awesome-icon>
        </button>

        <button
          class="btn btn-xs btn-circle btn-ghost"
          @click="exclude(producto)"
        >
          <font-awesome-icon icon="fas fa-trash"></font-awesome-icon>
        </button>
      </div>
      <div v-else>
        <button
          class="btn btn-xs btn-circle btn-ghost"
          @click="restore(producto)"
        >
          <font-awesome-icon
            icon="fas fa-arrow-rotate-left"
          ></font-awesome-icon>
        </button>
      </div>
    </div>
  </div>
</template>
