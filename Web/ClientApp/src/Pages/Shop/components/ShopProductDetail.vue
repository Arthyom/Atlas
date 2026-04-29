<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import { useAtlasCartStore } from "@/Pages/Shared/store/AtlasCartStore";
import { computed, ref } from "vue";
import { useAtlasComposableRouterHtmlActions } from "@/Models/Composables/AtlasComposableRouterActions";

import SwiperClass from "swiper";

import { Swiper, SwiperSlide } from "swiper/vue";
import { Navigation, Pagination, Scrollbar } from "swiper/modules";

import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";
import { IDtoEtiqueta } from "@/Models/DTOs/IDtoEtiqueta";

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

const imageIndexSelected = ref(0);
const etiquetaIndexSelected = ref(0);
const selectedParentEtiqueta = ref<IDtoEtiqueta | null>(null);
const productosTotales = ref(0);

const defImage = ref(props.producto?.imagenes?.[0] || "");
const itemSelector = ref<HTMLDivElement[] | null>(null);

const setSelectedImage = (event: any, image: string) => {
  const imageContainer = event.currentTarget.firstChild as HTMLDivElement;
  const itemsList = itemSelector.value;

  itemsList?.forEach((item) => {
    item.classList.remove("ring-primary");
  });

  imageContainer.classList.add("ring-primary");
  defImage.value = image;
};

const selectedModel = computed(
  () => props.producto.modelos?.[imageIndexSelected.value] || null,
);

const selectedEtiqueta = computed(() => {
  const modelo = props.producto.modelos?.[imageIndexSelected.value] || null;

  return modelo?.etiquetas?.[etiquetaIndexSelected.value] || null;
});

const selectedSubEtiquetas = computed(
  () => selectedParentEtiqueta.value?.etiquetasRelacionadas,
);

interface ISelectedTag {
  selected: boolean;
  text: string;
}
</script>

<template>
  <div
    class="card bg-white w-full shadow-sm flex justify-center mb-8"
    @mouseenter="isVisible = true"
    @mouseleave="isVisible = false"
  >
    <div class="flex px-3 py-2 mb-2 text-left">
      <span class="flex-1 text-2xl font-extralight">{{
        props.producto.nombre
      }}</span>
      <span class="text-2xl font-bold">{{
        $n(props.producto.precioUnitario, "currency")
      }}</span>
    </div>

    <div v-if="selectedModel?.etiquetas">
      <div class="flex flex-wrap flex-row justify-center gap-2">
        <div
          class="badge badge-info pl-1 pr-2"
          v-for="(etiqueta, index) in selectedModel?.etiquetas?.filter(
            (x) => !x.etiquetaId,
          )"
        >
          <input
            type="radio"
            :name="selectedModel?.nombre"
            class="checkbox checkbox-xs checkbox-primary"
            @click="selectedParentEtiqueta = etiqueta"
          />

          {{ etiqueta?.nombre }}
        </div>
      </div>
    </div>

    <div v-if="selectedSubEtiquetas" class="mt-4">
      <div class="flex flex-wrap flex-row justify-center gap-2">
        <div
          class="badge badge-info pl-1 pr-2"
          v-for="(etiqueta, index) in selectedSubEtiquetas"
        >
          <input
            type="checkbox"
            :name="selectedParentEtiqueta?.nombre"
            class="checkbox checkbox-xs checkbox-primary"
          />

          {{ etiqueta?.nombre }}
        </div>
      </div>
    </div>

    <!-- <div>
      <div class="flex flex-wrap flex-row  justify-center gap-2">
        <button v-for="etiqueta in getTags" class="btn " 
        @click="etiqueta.selected = true"
        :class="{'btn-disable': !etiqueta.selected , 'btn-info': etiqueta.selected}">
         {{etiqueta.text}}
        </button>
      </div>
    </div> -->

    <div>
      <swiper
        :slides-per-view="1"
        :space-between="1"
        :navigation="true"
        :modules="[Navigation]"
      >
        <template v-if="selectedModel">
          <swiper-slide
            v-for="imageModel in selectedModel?.imagenes"
            :key="imageModel"
            class="px-6"
          >
            <figure class="p-2">
              <div v-if="imageModel">
                <img
                  :src="getFileFrom('ModeloAnonimous', 'store', imageModel)"
                  class="min-h-110 max-h-110 w-full object-fill"
                />
              </div>
              <div v-else>
                <img :src="noFile()" class="min-h-60 max-h-60 w-full" />
              </div>
            </figure>
          </swiper-slide>
        </template>
        <template v-else>
          <swiper-slide class="p-1">
            <figure class="p-2">
              <img :src="noFile()" class="min-h-60 max-h-60 w-full" />
            </figure>
          </swiper-slide>
        </template>
      </swiper>
    </div>

    <!-- <transition
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
              <font-awesome-icon
                icon="fas fa-cart-arrow-down"
              ></font-awesome-icon>
            </button>
          </div>
        </div>
      </div>
    </transition> -->

    <div class="flex justify-center p-0 m-0 mb-2">
      <div class="tooltip" :data-tip="selectedModel?.descripcion">
        <img
          src="/logo.png"
          :class="{
            'ring-blue-400': selectedModel?.descripcion.length,
            'ring-gray-400': !selectedModel?.descripcion.length,
          }"
          class="avatar rounded-full m-2 ring-3 ring-offset-6 min-h-16 max-h-16"
        />
      </div>
    </div>

    <div class="mx-2">
      <div class="flex flex-row">
        <swiper :pagination="true" :slides-per-view="4" :space-between="0">
          <swiper-slide
            v-for="(imageModel, index) in props.producto.modelos || []"
            :key="index"
            class="p-1 pb-4"
          >
            <div
              @click="
                setSelectedImage($event, imageModel.imagenes?.[0] || '');
                imageIndexSelected = index;
              "
              class="avatar"
            >
              <div
                ref="itemSelector"
                class="item-selector w-20 rounded-full m-2 ring-gray-400 ring-3 ring-offset-2"
              >
                <img
                  :src="
                    getFileFrom(
                      'ModeloAnonimous',
                      'store',
                      imageModel.imagenes?.[0] || '',
                    )
                  "
                />
              </div>
            </div>
          </swiper-slide>
        </swiper>
      </div>
    </div>

    <!-- <div class="flex justify-center bg-green-500 px-16">
      <button class="btn btn-light rounded-l-2xl rounded-bl-2xl" @click=" productosTotales >0 ? productosTotales-- : productosTotales">-</button>
      <div class="flex-1 flex flex-col bg-red-400 justify-center items-center">
        <label for="">{{ productosTotales }}</label>
      </div>

      <button class="btn btn-block btn-light"></button>

      <span class="countdown font-mono text-xl">
  <span style="--value:519; --digits: 3;" aria-live="polite" aria-label="519*">519</span>
</span>

      <button class="btn btn-light rounded-r-2xl rounded-br-2xl" @click="productosTotales++">+</button>
    </div> -->

    <div class="join w-100 px-4 mb-4">
      <button class="btn btn-neutral  join-item rounded-l-2xl rounded-bl-2xl" @click=" productosTotales >0 ? productosTotales-- : productosTotales">
          <font-awesome-icon icon="fas fa-minus" size="md" />
      </button>
      
      <button class="btn btn-neutral btn-outline flex-1 join-item ">{{productosTotales}}</button>

      <button class="btn btn-neutral join-item rounded-r-2xl rounded-br-2xl" @click="productosTotales++">
                  <font-awesome-icon icon="fas fa-plus" size="md" />
      </button>

    </div>

  </div>
</template>
