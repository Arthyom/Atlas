<script setup lang="ts">
import {
  IAtlasCustomLink,
  IAtlasCustomLinks,
} from "@/Models/Interfaces/IAtlasCustomLink";
import { Link } from "@inertiajs/vue3";

defineProps<IAtlasCustomLinks>();
</script>

<template>
  <div class="drawer-side z-500">
    <label
      for="my-drawer-4"
      aria-label="close sidebar"
      class="drawer-overlay"
    ></label>
    <ul class="menu bg-base-200 text-base-content min-h-full w-40 p-4">
      <template v-if="linkItems != null">
        <template v-for="link in linkItems">
          <Link :href="link.path" class="btn btn-primary w-full my-2">
            {{ link.label }}
          </Link>
        </template>
      </template>
    </ul>
  </div>
</template>
