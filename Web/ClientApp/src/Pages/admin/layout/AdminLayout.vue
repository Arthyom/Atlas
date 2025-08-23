<script setup lang="ts">
import AtlasInfiniteLoader from "@/Pages/Shared/Components/AtlasInfiniteLoader.vue";
import AdminFooterComponent from "../components/AdminFooterComponent.vue";
import AdminNavBarComponent from "../components/AdminNavBarComponent.vue";
import { useAtlasStoreLoading } from "@/Pages/Shared/store/AtlasStoreLoading";
import AtlasSideBarComponent from "@/Pages/Shared/Components/AtlasSideBarComponent.vue";
import { IAtlasCustomLinks } from "../../../Models/Interfaces/IAtlasCustomLink";
import { adminLinkItems } from "../data/links.data";

const vs = useAtlasStoreLoading();
</script>

<template>
  <div class="drawer drawer-end  ">
    <input id="my-drawer-4" type="checkbox" class="drawer-toggle" />

    <div class="drawer-content h-dvh ">
      <AtlasInfiniteLoader></AtlasInfiniteLoader>

      <div class="sticky top-0 z-20">
        <AdminNavBarComponent></AdminNavBarComponent>
      </div>

      <div class="   ">
        <slot></slot>
      </div>

    </div>

    <AtlasSideBarComponent v-bind="adminLinkItems"></AtlasSideBarComponent>
  </div>
</template>
