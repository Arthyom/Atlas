<script setup lang="ts">
import AtlasCustomModalControl from "@/Pages/Shared/Components/AtlasCustomModalControl.vue";
import { EnumPurchaseModalType } from "../Enums/ModalType.enum";
import {
  onBeforeMount,
  onBeforeUnmount,
  onBeforeUpdate,
  ref,
  watch,
  watchEffect,
} from "vue";
import AtlasCustomImageStack from "@/Pages/Shared/Components/AtlasCustomImageStack.vue";
import { AtlasHelperProducto } from "@/Models/Helpers/AtlasHelper";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";
import axios from "axios";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AtlasCustomImageCircleSmControl from "@/Pages/Shared/Components/AtlasCustomImageCircleSmControl.vue";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import { IPurchaseModalConf } from "../interfaces/IPurchaseModalConf";

const props = defineProps<IPurchaseModalConf>();
const products = ref<IDtoProducto[]>([]);
const showModal = ref(false);

onBeforeMount(async () => {
  const { getById, getUrl } = useAtlasComposableAjaxActions(
    "Producto",
    "admin",
    null
  );

  if (props.productos) {
    // products.value = props.items?.map(AtlasHelperProducto.mapToDtoProducto)
    // products.value.forEach( async(x) => {

    //     const val = await getById(x.id)

    //     x = val ? val: x
    // });
    const s = await Promise.all(
      props.productos.map(async (x) => {
        const ca = x.cantidad;
        // const m = await axios.get<IAtlasMixedResponse<IDtoProducto>>('http://localhost:5000/admin/producto/json/1013')
        const m = await getById(x.id);

        if (m) {
          m.cantidad = ca;
          return m;
        }
      })
    );
    // if(s[0].mainResourceCollection){

    //     products.value = s[0].mainResourceCollection
    // }
    products.value = s.filter((x) => x !== undefined);
  }
});
showModal.value = true;
</script>

<template>
  <AtlasCustomModalControl
    v-if="showModal"
    @close-modal="$emit('close-form', false)"
  >
    <template #title>
      <h1 class="text-xl text-center">Productos en la orden</h1>
      <!-- <h2 class="text-center font-light">Total ${{ 40 }}</h2> -->
    </template>

    <template #body>
      <div class="grid grid-cols-1">
        <div class="flex flex-col w-full pl-2 gap-3">
          <div class="flex  w-full" v-for="item in products">
            <AtlasCustomImageCircleSmControl v-bind:producto="item" />
            <div class="w-full ml-2 flex flex-col justify-center">
              <span class="font-bold text-lg">{{ item.nombre }}</span>
              <span class="text-md">
                Unidades:
                <span class="text-blue-800 font-bold">
                  {{ item.cantidad }}
                </span>
              </span>
            </div>
          </div>
        </div>
      </div>

      <!-- </AtlasCustomImageCircleSmControl> -->
      <!-- <AtlasCustomImageStack 
                v-for="item in products"
                v-bind="item"
                >
    
                </AtlasCustomImageStack> -->
    </template>
  </AtlasCustomModalControl>
</template>
