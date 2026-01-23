<script setup lang="ts">
import AtlasTableWrapper from "@/Pages/Shared/Components/AtlasTableWrapper.vue";
import IAtlasCustomTableConfig from "../../../../Models/Interfaces/IAtlasCustomTableConfig";
import { config } from "@fortawesome/fontawesome-svg-core";
import { IDtoEnPeShippingRate } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingRate";
import AtlasTableWrapperCustom from "@/Pages/Shared/Components/AtlasTableWrapperCustom.vue";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import { ref, onBeforeMount } from 'vue';

// defineProps<{ rates: IDtoEnPeShippingRate[] }>();

const composables = useAtlasComposableAjaxActions('envio','admin', 'GetShippingProviders');

const rates = ref<IAtlasMixedResponse<IDtoEnPeShippingRate>>();

 onBeforeMount( async()=>{
  rates.value = await composables.getUrl<IAtlasMixedResponse<IDtoEnPeShippingRate>>()
})

  // rates.value = await composables.getUrl<IAtlasMixedResponse<IDtoEnPeShippingRate>>()


const tableConfigs: IAtlasCustomTableConfig = {
  configs: {
    title: "Disponibles",
    resource: "Purchase",
    headersLabels: ["Descripcion"],
    hideActions: true,
    hideAddButton: true,
    hideHeaders: true,
  },
};
</script>

<template>
    <h2 class="font-bold">Seleccionar proveedor</h2>
  <AtlasTableWrapperCustom v-bind="tableConfigs">
    <template v-slot:default>
      <tr v-for="shippingRate in rates?.mainResourceCollection" class="">
        <td class="flex p-0 pl-2">
          <!-- <div class="flex  bg-green-400 "> -->
          <div class="flex flex-col items-center py-2">
            <div
              class="badge badge-info badge-xs"
              v-if="shippingRate.packageSize"
            >
              Pick Up
            </div>
            <input type="radio" name="radio-9" class="radio radio-info mt-2" @click="$emit('selected-ok', shippingRate)" />
          </div>

          <!-- <div class="flex  flex-col items-center p-1 ">
                                    
                                    <div class="avatar">
                                        <div class="w-15 md:w-22 rounded-full">
                                            <img src="https://img.daisyui.com/images/profile/demo/gordon@192.webp" />
                                        </div>
                                    </div>
    
                            </div> -->

          <div class="flex flex-1 ml-2 m-1 justify-start text-left">
            <div>
              <div class="font-extrabold lg:text-lg">
                {{ shippingRate.deliveryType.company }}
              </div>
              <div class="flex-col lg:flex text-xs gap-2">
                <div
                  class="flex flex-col md:flex-row items-start font-bold text-[10px] md:text-sm"
                >
                  {{ shippingRate.deliveryType.description }}
                </div>
                <div class="text-[10px] md:text-sm">
                  {{ shippingRate.deliveryType.feature }}
                </div>
              </div>
            </div>
          </div>

          <div class="flex flex-col grow-0 p-2 text-center justify-center">
            <div class="w-full">
              <div class="text-md md:text-lg font-extrabold">
                ${{ shippingRate.cost }}
              </div>
              <div class="text-xs md:text-sm">
                {{ shippingRate.currency }}
              </div>
            </div>
          </div>
          <!-- </div> -->
        </td>
      </tr>
    </template>
  </AtlasTableWrapperCustom>
</template>
