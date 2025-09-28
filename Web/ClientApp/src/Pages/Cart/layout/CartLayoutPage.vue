<script lang="ts" setup>
import { Link, router } from '@inertiajs/vue3';

defineProps<{step:number, totalPago:number, totalProductos:number}>()


const goBack = () =>{
  router.get('/store/shop/index')
}


</script>


<template>
  
    <div class="menu menu-horizontal w-full bg-base-200  ">
      <h2 class="text-lg font-bold self-center" >Mi Carrito de compras</h2>
      
      <div class="flex flex-1 justify-end">
        <button class="btn btn-circle" @click="goBack">
          <font-awesome-icon icon="fas fa-arrow-left"></font-awesome-icon>
        </button>
        <button class="btn btn-circle" @click="$emit('destroyCart')">
          <font-awesome-icon icon="fas fa-close"></font-awesome-icon>
        </button>
      </div>
    </div>

  <ul
        class="steps steps-horizontal w-full pt-3 bg-white text-xs font-light md:text-lg md:font-normal"
      >
        <li class="step" :class="{ 'step-info': step == 1 || step > 1 }">
          <span class="">Productos</span>
        </li>
        <li class="step text" :class="{ 'step-info': step >= 2 }">
          <span class=" ">Direccion</span>
        </li>
        <li class="step" :class="{ 'step-info': step >= 3 }">
          <span class=" ">Pago</span>
        </li>
        <li class="step" :class="{ 'step-info': step >= 4 }">
          <span class="">Finalizar</span>
        </li>
      </ul>

      <div class="flex flex-col text-center py-3">
        <div class="font-light text-2xl">Productos: {{ totalProductos }}</div>
        <div class="font-light text-8xl">
          {{ totalPago }}
        </div>
      </div>
      
      <slot>

      </slot>
</template>