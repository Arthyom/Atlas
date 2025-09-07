<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { Link, router } from '@inertiajs/vue3';
import { useCartStore } from '../store/cart.store';
import CartProductViewer from './CartProductViewer.vue';
import { useAtlasCartStore } from '@/Pages/Shared/store/AtlasCartStore';


const { length, products, totalProductos, totalPago } =  storeToRefs( useAtlasCartStore() )


const goToCart =() =>{
  router.get('/store/cart/index')
}
</script>

<template>
  
  <template v-if="length > 0">

      <!-- <div  @click="goto" tabindex="0" role="button" class="btn btn-ghost btn-circle">
    
    <div class="indicator">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        class="h-7 w-7"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z"
        />
      </svg>
      <span class="badge badge-sm badge-accent indicator-item">
        {{ length }}
      </span>
    </div>
  </div> -->




    <div class="dropdown dropdown-start">
      <div tabindex="0" role="button" class="btn btn-ghost btn-circle">
        <div class="indicator">
           <svg
        xmlns="http://www.w3.org/2000/svg"
        class="h-7 w-7"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z"
        />
      </svg>
          <span class="badge badge-sm badge-soft indicator-item">{{ totalProductos }}</span>
        </div>
      </div>
      <div
        tabindex="0"
        class="card card-compact dropdown-content bg-base-300 z-18 mt-3 w-52 h-80 shadow">
        <div class="card-body p-2">
          <div class="card-title">
            <div class="flex w-full ">
                    
                        <span class="text-info font-bold text-center text-2xl flex-1 self-center">{{ totalPago }}</span>
                        <button @click="goToCart" class="btn btn-sm btn-primary self-center">
                          Pagar
                        </button>
            </div>
          </div>

          <div class="divider m-0"></div>

          <div class="cardody">
            <div class="grid grid-cols-2 gap-y-3">
              <template v-for="p in products">
                
                <CartProductViewer v-bind="p"/>
              </template>
            </div>
          </div>
          
        </div>
      </div>
    </div>

  </template>

</template>
