<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { useAtlasCartStore } from "@/Pages/Shared/store/AtlasCartStore";

const props = defineProps<IAtlasDtoProducto>();

const { getFirstFileForProducto } = useAtlasComposableUseFilesFetcher();

const { increase, decrease, restore, exclude } = useAtlasCartStore();
</script>

<template>
  <div class="">
    <div class="flex flex-col m-0 justify-center">
      <div class="flex ">
        <div class="absolute z-10">
          <button
          :class="{
            'btn-error' : props.selected,
            'btn-success' : !props.selected
          }"
            class="btn btn-sm  md:btn-sm lg:btn-md btn-base-100 btn-circle items-center"
          >
            {{ props.cantidad }}
          </button>
        </div>
        <div class="flex w-full justify-center">
          <div class="avatar flex justify-center">
            <div class="w-18 rounded-full">
              <img :src="getFirstFileForProducto(props)" />
            </div>
          </div>
        </div>
      </div>

      <div class="join justify-center" v-if="!props.selected">
        <button
          @click="increase(props)"
          class="btn btn-xs join-item rounded-l-full"
        >
          <font-awesome-icon icon="fas fa-plus" size="xs" />
        </button>
        <button
          @click="decrease(props)"
          class="btn btn-xs join-item rounded-r-full"
        >
          <font-awesome-icon icon="fas fa-minus" size="xs" />
        </button>

        <button @click="exclude(props)" 
        class="btn btn-xs join-item rounded-full ml-2">
          <font-awesome-icon icon="fas fa-trash" size="xs" />
        </button>
      </div>

      <div v-else class="flex justify-center">
        <button @click="restore(props)" class="btn btn-xs btn-circle ml-2">
          <font-awesome-icon icon="fas fa-circle" size="xs" />
        </button>
      </div>
    </div>
  </div>
</template>
