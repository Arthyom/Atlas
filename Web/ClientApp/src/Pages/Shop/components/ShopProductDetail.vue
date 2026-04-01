<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import { useAtlasCartStore } from "@/Pages/Shared/store/AtlasCartStore";
import { ref } from "vue";
import { useAtlasComposableRouterHtmlActions } from "@/Models/Composables/AtlasComposableRouterActions";

import { Swiper, SwiperSlide } from "swiper/vue";

import "swiper/css";

const props = defineProps<{ producto: IDtoProducto; showOptions?: boolean }>();

const {
  noFile,
  getFirstFileForProducto,
  getFileFrom,
  getImageAt,
  getLastImage,
} = useAtlasComposableUseFilesFetcher();
const { length, addProduct } = useAtlasCartStore();
const isVisible = ref(false);
const { getHtml } = useAtlasComposableRouterHtmlActions();

const defImage = ref(props.producto?.imagenes?.[0] || '');
const itemSelector = ref<HTMLDivElement [] | null>(null);

const setSelectedImage = (event:any, image: string) => {
  const imageContainer = event.currentTarget.firstChild as HTMLDivElement;
  const itemsList = itemSelector.value;

  itemsList?.forEach((item) => {
    item.classList.remove("ring-primary");
  });

  imageContainer.classList.add("ring-primary");
  defImage.value = image;

};
</script>

<template>
  <div
    class="card bg-white w-full shadow-sm flex justify-center mb-8"
    @mouseenter="isVisible = true"
    @mouseleave="isVisible = false"
  >
  <div class="flex px-3 py-2 text-left">
        <span class="flex-1 text-2xl font-extralight ">{{
          props.producto.nombre
        }}</span>
        <span class="text-2xl font-bold " >{{
          $n( props.producto.precioUnitario, 'currency' )
        }}</span>
      </div>
    <figure class=" p-2">
      <template v-if="props.producto.imagenes">
        <img
          :src="
            getFileFrom(
              'productoAnonimous',
              'store',
              defImage,
            )
          "
          class="min-h-110 max-h-110 w-full object-fill"
        />
      </template>
      <template v-else>
        <img :src="noFile()" class="min-h-60 max-h-60 w-full" />
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
      <div v-show="isVisible" class="w-full absolute bottom-50">
        <div class="w-full">
          <div
            class="flex justify-center gap-2 p-2 bg-base-300 mx-18 rounded-lg"
          >
            <button class="btn btn-circle">
              <font-awesome-icon icon="fas fa-dollar"></font-awesome-icon>
            </button>
            <button class="btn btn-circle" @click="addProduct(props.producto)">
              <font-awesome-icon icon="fas fa-car"></font-awesome-icon>
            </button>
          </div>
        </div>
      </div>
    </transition>

    
    <div class="flex justify-center p-0 m-0">
      <img src="/logo.png" class="min-h-22 max-h-22" />
    </div>

    <div class="">

      <div class="flex flex-row">
        <swiper :navigation="true" :slides-per-view="4" :space-between="0">
          <swiper-slide v-for="image in props.producto.imagenes" :key="image" class="p-1 ">
            <div @click="setSelectedImage($event,image)" class="avatar">
              <div ref="itemSelector" class="item-selector w-20 rounded-full m-2  ring-gray-400 ring-3 ring-offset-2">
                <img :src="getFileFrom('productoAnonimous', 'store', image)" />
              </div>
            </div>
          </swiper-slide>
        </swiper>
      </div>
    </div>
  </div>
</template>
