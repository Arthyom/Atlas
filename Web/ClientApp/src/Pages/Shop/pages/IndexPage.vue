<script setup lang="ts">
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import StoreFrontLayOutPage from "@/Pages/layouts/store-front/StoreFrontLayOutPage.vue";
// import ProductComponent from "@/Pages/Producto/components/ProductComponent.vue";
import { Link } from "@inertiajs/vue3";
import ShopProduct from "../components/ShopProduct.vue";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";

import { Swiper, SwiperSlide } from "swiper/vue";

import "swiper/css";

import { onMounted, onUnmounted, ref } from "vue";
import ShopProductSlide from "../components/ShopProductSlide.vue";

const props = defineProps<IAtlasMixedResponse<IDtoProducto>>();

const showButton = ref(false);

const handleScroll = () => {
    if (window.scrollY > 2000) {
        showButton.value = true;
    } else {
        showButton.value = false;
    }
};

const scrollToTop = () => {
    window.scrollTo({ top: 0, behavior: "smooth" });
    showButton.value = false;
};

const swiperInstance = ref(null);

const onSwiper = (swiper: any) => {
    swiperInstance.value = swiper;
};

const onSlideChange = () => {
    console.log("Slide changed");
};

// Attach and detach scroll event listener
onMounted(() => {
    window.addEventListener("scroll", handleScroll);
});

onUnmounted(() => {
    window.removeEventListener("scroll", handleScroll);
});
</script>

<template>
    <StoreFrontLayOutPage>
        <div class="px-2">
            <!-- <div
        class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-4"
      > -->
            <div class="card bg-base-100 shadow-sm my-15">
                <div class="card-body m-1 p-1">
                    <!-- <h2 class="card-title">CapOs</h2> -->
                    <h2 class="text-3xl font-bold text-center m-0 p-0">CapOs</h2>
                </div>
                <figure>
                    <img src="/logo.png" alt="Shoes" />
                </figure>
            </div>

            <div class="my-20">
                <h1 class="text-4xl mb-2 text-center">Los Más Vendidos</h1>
                <swiper 
                :slides-per-view="2" 
                :space-between="10" 
                @swiper="onSwiper" 
                @slideChange="onSlideChange"
        >
          <swiper-slide
            v-for="producto in props.mainResourceCollection"
            :key="producto.id"
          >
                        <ShopProductSlide v-bind="producto"></ShopProductSlide>
                    </swiper-slide>
                </swiper>
            </div>

            <div>
                <h1 class="text-4xl mb-2 text-center">Nuestro Catalogo</h1>
                <div 
                class="my-2 p-1"
                 v-for="producto in props.mainResourceCollection" 
                 :key="producto.id"
                 >
                    <ShopProduct v-bind="producto" ></ShopProduct>
                </div>
            </div>
            <!-- </div> -->
        </div>

        <div 
        class="fixed bottom-4 right-4 z-50 transition-all duration-300 ease-in-out" 
        :class="{ 'opacity-0 pointer-events-none': !showButton }"
        >
            <button
                @click="scrollToTop"
                class="bg-blue-500 hover:bg-blue-600 text-white p-4 rounded-full shadow-lg flex items-center justify-center transition-all duration-300 transform hover:scale-110"
            >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="h-6 w-6"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M5 10l7-7m0 0l7 7m-7-7v18"
          />
                </svg>
            </button>
        </div>
    </StoreFrontLayOutPage>
</template>
