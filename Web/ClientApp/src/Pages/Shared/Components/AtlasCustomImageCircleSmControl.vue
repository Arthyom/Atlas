<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from '@/Models/Composables/AtlasComposableFilesFetcher';
import { IDtoProducto } from '@/Pages/Producto/DTOs/IDtoProducto';

const props =defineProps<{ producto: IDtoProducto, useButtonIndicator?:boolean}>()
const { getFirstFileForProducto, noFile } = useAtlasComposableUseFilesFetcher();

</script>


<template>

<div >

    <div class="absolute z-15 left-[30px]" v-if="useButtonIndicator">
      <button
        class="btn btn-sm md:btn-sm lg:btn-md btn-base-100 btn-circle items-center"              
      >
        {{ producto.cantidad }}
      </button>
    </div>


    <div class="avatar-group bg-blck w-full">
      <div
      class="avatar"
      :style="`border-color:${producto.categoriaColor}`"
      >
        <div class="w-15 md:w-20 lg:w-30">
            <img
                class=""
              :src="getFirstFileForProducto(props.producto, 'admin')"
            />
          </div>
        </div>
      </div>
</div>


</template>