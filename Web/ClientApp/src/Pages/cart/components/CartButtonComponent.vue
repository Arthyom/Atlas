<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { atlasUseCartStore } from '../store/cart.store';
import { Link, router } from '@inertiajs/vue3';


    const { products, length } =  storeToRefs( atlasUseCartStore() )


    const goto = () =>{
           router.get('/cart/index')
    }

</script>

<template>
  
  <template v-if="length > 0">

      <div  @click="goto" tabindex="0" role="button" class="btn btn-ghost btn-circle">
    
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
  </div>

  </template>

</template>
