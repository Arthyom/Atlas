<script setup lang="ts">
import StoreFrontFooterComponent from "./components/StoreFrontFooterComponent.vue";
import StoreFrontNavBarComponent from "./components/StoreFrontNavBarComponent.vue";
import StoreFrontSideBarComponent from "../../Shared/Components/AtlasSideBarComponent.vue";
import { StoreLinkItems } from "@/Pages/admin/data/links.data";

</script>

<template>
  <div class="drawer drawer-end">
    <input id="my-drawer-4" type="checkbox" class="drawer-toggle" />

    <div class="drawer-content">
        
      <div class="h-screen flex flex-col bg-red-s400">
        <div class="sticky top-0 z-20 w-full">
          <StoreFrontNavBarComponent></StoreFrontNavBarComponent>
        </div>

        <div class="flex-1 m-5">
          <slot></slot>
        </div>
        <StoreFrontFooterComponent></StoreFrontFooterComponent>
      </div>
    </div>
    
    <StoreFrontSideBarComponent v-bind="StoreLinkItems"></StoreFrontSideBarComponent>
  </div>
</template>
