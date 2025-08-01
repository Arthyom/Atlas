<script setup lang="ts">
import IAtlasProducto from "@/Models/Entities/IAtlasProducto";
import Producto from "@/Models/Entities/IAtlasProducto";
import { atlasUseCartStore } from "@/Pages/cart/store/cart.store";
import StoreFrontLayOutPage from "@/Pages/layouts/store-front/StoreFrontLayOutPage.vue";
import ProductComponent from "@/Pages/Producto/components/ProductComponent.vue";
import {Link} from "@inertiajs/vue3";

const ps : IAtlasProducto[ ] = [
  {categoriaId: 1, id: 1, descripcion: 's', nombre: 'sss',precioMayore: 1, precioUnitario:0}
]

</script>

<template>
  <StoreFrontLayOutPage>
    <div class="flex flex-col">
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4   ">
        <template v-for="product in ps" :key="product.id">
          <ProductComponent v-bind="product"></ProductComponent>
        </template>
      </div>
    </div>
  </StoreFrontLayOutPage>
</template>
