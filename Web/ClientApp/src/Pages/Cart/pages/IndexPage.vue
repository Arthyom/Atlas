<script setup lang="ts">
import StoreFrontLayOutPage from '@/Pages/layouts/store-front/StoreFrontLayOutPage.vue';
import { useCartStore } from '../store/cart.store';
import { AtlasComposableCustomSwipper } from '@/Models/Composables/AtlasComposableCustomSwipper';
import AtlasCustomProductControl from '@/Pages/Shared/Components/AtlasCustomProductControl.vue';
import { useAtlasCartStore } from '@/Pages/Shared/store/AtlasCartStore';
import { storeToRefs } from 'pinia';

const {products, totalProductos} = storeToRefs( useAtlasCartStore() )
const { swipeNext, swipePrev, step } = AtlasComposableCustomSwipper("swipper");

</script>

<template>

    <StoreFrontLayOutPage>

         <div class="w-full">
            
            <ul
        class="sticky top-16 z-21 steps steps-horizontal w-full pt-3 bg-white"
      >
        <li class="step" :class="{ 'step-info': step == 1 || step > 1 }">
          Productos
        </li>
        <li class="step" :class="{ 'step-info': step >= 2 }">Direccion</li>
        <li class="step" :class="{ 'step-info': step >= 3 }">Pago</li>
        <li class="step" :class="{ 'step-info': step >= 3 }">Terminar</li>

      </ul>
      <div>
        <swiper-container
          ef="swipper"
          class="w-full"
          slides-per-view="1"
          speed="500"
          css-mode="true"
        >
        <swiper-slide>
            <span>Total en el carrito {{ totalProductos }}</span>
            <div class="grid grid-cols-2 md:grid-cols-3 gap-2">
                <template v-for="p in products">
                    <AtlasCustomProductControl v-bind="p"></AtlasCustomProductControl>
                </template>
            </div>
        </swiper-slide>
        <swiper-slide>2</swiper-slide>
        <swiper-slide>3</swiper-slide>
        <swiper-slide>4</swiper-slide>

        </swiper-container>
      </div>

         </div>

    </StoreFrontLayOutPage>

</template>