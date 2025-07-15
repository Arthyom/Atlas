<script setup lang="ts">
import { atlasUseCartStore } from "@/Pages/cart/store/cart.store";
import StoreFrontLayOutPage from "@/Pages/layouts/store-front/StoreFrontLayOutPage.vue";
import ProductComponent from "@/Pages/products/components/ProductComponent.vue";
import {Link} from "@inertiajs/vue3";



</script>

<template>
  <StoreFrontLayOutPage>
    <div class="flex flex-col">
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4   ">
        <ProductComponent v-for="item in [1,1,1,1,]" :key="item"></ProductComponent>
      </div>
    </div>
  </StoreFrontLayOutPage>
</template>
