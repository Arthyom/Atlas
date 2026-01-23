<script setup lang="ts">
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import StoreFrontLayOutPage from "@/Pages/layouts/store-front/StoreFrontLayOutPage.vue";
// import ProductComponent from "@/Pages/Producto/components/ProductComponent.vue";
import {Link} from "@inertiajs/vue3";
import ShopProduct from "../components/ShopProduct.vue";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";

const props = defineProps<IAtlasMixedResponse<IDtoProducto>>()

</script>

<template>
  <StoreFrontLayOutPage>
    <div class="flex flex-col">
      <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-4   ">
        <template v-for="producto in props.mainResourceCollection" :key="product">
          <ShopProduct v-bind="producto" ></ShopProduct>
        </template>
      </div>
    </div>
  </StoreFrontLayOutPage>
</template>
