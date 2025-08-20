<script setup lang="ts">
import StoreFrontFooterComponent from "./components/StoreFrontFooterComponent.vue";
import StoreFrontNavBarComponent from "./components/StoreFrontNavBarComponent.vue";
import StoreFrontSideBarComponent from "../../Shared/Components/AtlasSideBarComponent.vue";
</script>

<template>
  <div class="drawer drawer-end">
    <input id="my-drawer-4" type="checkbox" class="drawer-toggle" />

    <div class="drawer-content">
        
      <div class="h-screen flex flex-col bg-red-s400">
        <StoreFrontNavBarComponent></StoreFrontNavBarComponent>

        <div class="flex-1 m-5">
          <slot></slot>
        </div>
        <StoreFrontFooterComponent></StoreFrontFooterComponent>
      </div>
    </div>
    
    <StoreFrontSideBarComponent></StoreFrontSideBarComponent>
  </div>
</template>
