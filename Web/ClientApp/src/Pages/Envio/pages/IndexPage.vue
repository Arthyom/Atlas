<script setup lang="ts">
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import IDtoCategoria from "@/Pages/Categoria/DTOs/IDtoCategoria";
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import AtlasCustomModalControl from "@/Pages/Shared/Components/AtlasCustomModalControl.vue";
import AtlasTableWrapper from "@/Pages/Shared/Components/AtlasTableWrapper.vue";
import { reactive, Ref, ref } from "vue";
import OrderItemsDetails from "../components/OrderItemsDetails.vue";
import OrderPaymentDetails from "../components/OrderPaymentDetails.vue";
import OrderShippingDetails from "../components/OrderShippingDetails.vue";
import { EnumPurchaseModalType } from "../Enums/ModalType.enum";
import OrderOverViewDetails from "../components/OrderOverViewDetails.vue";
import { IPurchaseModalConf } from "../interfaces/IPurchaseModalConf";
import { IDtoEnvio } from "../interfaces/IDtoEnvio";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";
import { Link, router } from "@inertiajs/vue3";
import { MapOrdenStatusToHuman } from "@/Pages/Shop/Mapers/MapOrdenStatusToHuman";
import { IDtoOrder } from "@/Pages/Shop/pages/IDtoOrder";
import { EnumStateOrden } from "@/Pages/Shop/Enums/StatesOrder.enum";
import OrderGuideDetails from "../components/OrderGuideDetails.vue";

const props = defineProps<IAtlasMixedResponse<IDtoEnvio>>();

const modalConf = reactive<IPurchaseModalConf>({});

const selectedIndex = ref(0)

const tableConfig: IAtlasCustomTableConfig = {
  configs: {
    title: "Pedidos",
    resource: "Purchase",
    headersLabels: ["Descripcion", "Productos", "Envio", "Pago"],
  },
};

const toggleValue = (item: any) => {
  console.log("items", item);
  item.value = !item.value;
};

// const showSomeModal = async(type: EnumPurchaseModalType) => {
//   const mod = useAtlasComposableAjaxActions('', 'admin','GetShippingGuide/2')
//   router.get("/admin/envio/GetShippingGuide/2")
//   await mod.getUrl();
//   modalConf.isVisible = true;
//   modalConf.modalType = type;
// };

const showSomeModal = (type: EnumPurchaseModalType) => {
  // const mod = useAtlasComposableAjaxActions('', 'admin','GetShippingGuide/2')
  // router.get("/admin/envio/GetShippingGuide/2")
  // await mod.getUrl();
  modalConf.isVisible = true;
  modalConf.modalType = type;
};

const hideForm = (event: any) => {
  modalConf.isVisible = event;
};

const checkModalType = (typeInput: EnumPurchaseModalType) => {
  return modalConf.modalType === typeInput;
};

const getItemsFromCollection = (index:number) =>{
  return props.mainResourceCollection[index].order.productos;
}

const getMainItemFromResponse = (index:number) =>{
  return   props.mainResourceCollection[index];
;
  // const s =  props.mainResourceCollection[index].order;
  // console.log('las props ext',s)
  // return s
}

const getEnvioByIndex = (index:number) =>{
  return  props.mainResourceCollection[index];
}

const mapOrdenStatus = (ordenStatus: EnumStateOrden) =>{
  return MapOrdenStatusToHuman.mapToTextFromInt( ordenStatus )
}

const mapOrdenStatusToColor = (ordenStatus: EnumStateOrden) =>{
  return MapOrdenStatusToHuman.mapToColorFromInt( ordenStatus )
}
</script>

<template>
  <template v-if="modalConf.isVisible">

 
    
  <OrderOverViewDetails
    v-bind="getMainItemFromResponse(selectedIndex)"
    @close-form="hideForm"
    v-if="checkModalType(EnumPurchaseModalType.OrderOverViewDetails)"
  >
  </OrderOverViewDetails>

  <OrderItemsDetails
   :productos="getItemsFromCollection(selectedIndex)"
    @close-form="hideForm"
    v-if="checkModalType(EnumPurchaseModalType.OrderItemsDetails)"
  >
  </OrderItemsDetails>

    <OrderPaymentDetails
      @close-form="hideForm"
      v-if="checkModalType(EnumPurchaseModalType.OrderPayment)"
    >
    </OrderPaymentDetails>

    <OrderShippingDetails
      v-bind="getEnvioByIndex(selectedIndex)"
      @close-form="hideForm"
      v-if="checkModalType(EnumPurchaseModalType.OrderShipping)"
    >
    </OrderShippingDetails>

    <OrderGuideDetails
      v-bind="getEnvioByIndex(selectedIndex)"
      @close-form="hideForm"
      v-if="checkModalType(EnumPurchaseModalType.OrderShippingGuide)"
    >

    </OrderGuideDetails>
 
  </template>

  
  <AdminLayout>

        <AtlasTableWrapper v-bind="tableConfig">


      <template v-slot:default>
        <tr
          v-for="(itemResource,i) in props.mainResourceCollection"
          :key="itemResource.order.folio"
        >
        <template v-if="itemResource.order">

         <!-- Small screen section -->
          <td class="md:hidden">
            <div
              class="md:hidden bg-base-300 border-base-300 shadow-x collapse border"
            >
              <input
                type="checkbox"
                class="peer"
                :checked="itemResource.selected"
                @change="itemResource.selected = !itemResource.selected"
              />

              <div
                class="p-2 collapse-title peer-checked:bg-black peer-checked:text-white"
              >
                  <div class="flex w-full">
                    <div class="flex  items-center  ">
                      <label class=" w-full">
                        <input
                          type="checkbox"
                          class="checkbox checkbox-info"
                          v-model="itemResource.selected"
                        />
                      </label>
                    </div>
                    <div class="text-xs lg:text-xl  lg:font-bold  w-full">
                      <div class="flex flex-col items-center gap-1">
                        <div class="badge" :class="mapOrdenStatusToColor(itemResource.order.status)">
                          {{ mapOrdenStatus( itemResource.order.status ) }}
                        </div>
                        <div class="flex flex-col text-center"><span class="font-bold">Folio</span> {{ itemResource.order.folio }}</div>
                      </div>
                    </div>
                  </div>
                </div>

              <div class="collapse-content gap-0 p-0  "  style="padding-bottom: 0px" >

                  <div class="flex   gap-2 bg-gren-500 justify-center  w-full  p-2">
                    <button
                      @click="
                        showSomeModal(EnumPurchaseModalType.OrderOverViewDetails)
                      "
                      class="btn  btn-md btn-info"
                    >
                      <font-awesome-icon icon="fas fa-circle-info" class="text-white"></font-awesome-icon>
                    </button>
            
    
                    <button
                      @click="
                        selectedIndex = i;
                        showSomeModal(EnumPurchaseModalType.OrderItemsDetails)
                      "
                      class="btn btn-md btn-info"
                    >
                      <font-awesome-icon icon="fas fa-table-list" class="text-white"></font-awesome-icon>
                    </button>
    
                    <button
                      @click="showSomeModal(EnumPurchaseModalType.OrderShipping)"
                      class="btn btn-md btn-info"
                    >
                      <font-awesome-icon icon="fas fa-truck" class="text-white"></font-awesome-icon>
                    </button>
    
                    <!-- <button
                      @click="showSomeModal(EnumPurchaseModalType.OrderPayment)"
                      class="btn btn-md btn-info"
                    >
                      <font-awesome-icon icon="fas fa-sack-dollar" class="text-white"></font-awesome-icon>
                    </button> -->

                    <button
                      @click="showSomeModal(EnumPurchaseModalType.OrderShippingGuide)"
                      class="btn btn-md btn-success"
                    >
                      <font-awesome-icon icon="fas fa-file" class="text-white"></font-awesome-icon>
                    </button>

                    <button
                      @click="showSomeModal(EnumPurchaseModalType.OrderShippingGuide)"
                      class="btn btn-md btn-error"
                    >
                      <font-awesome-icon icon="fas fa-file" class="text-white"></font-awesome-icon>
                    </button>
                  </div>


              </div>
            </div>
          </td>

          <!-- Large screen sectio -->
          <td class="hidden md:table-cell">
            <div class="flex flex-col items-center gap-1">
              <div class="badge" :class="mapOrdenStatusToColor(itemResource.order.status)">
                {{ mapOrdenStatus( itemResource.order.status) }}
              </div>

              <button
                @click="
                  showSomeModal(EnumPurchaseModalType.OrderOverViewDetails)
                "
                class="btn btn-ghost btn-circle btn-xl"
              >
                <div class="avatar avatar-placeholder">
                  <div
                    class="bg-neutral text-neutral-content w-12 rounded-full"
                  >
                    <font-awesome-icon icon="fas fa-circle-info" ></font-awesome-icon>
                  </div>
                </div>
              </button>

              <div class="text-lg">
                <span class="font-bold">Folio</span> <span> {{ itemResource.order.folio }} </span>
              </div>
            </div>
          </td>

          <td class="hidden md:table-cell">
            <div class="flex flex-col items-center gap-1">
              <button
                @click="showSomeModal(EnumPurchaseModalType.OrderItemsDetails)"
                class="btn btn-circle btn-xl"
              >
                <font-awesome-icon icon="fas fa-table-list" ></font-awesome-icon>
              </button>
            </div>
          </td>

          <td class="hidden md:table-cell">
            <div class="flex flex-col items-center gap-1">
              <button
                @click="showSomeModal(EnumPurchaseModalType.OrderShipping)"
                class="btn btn-circle btn-xl"
              >
                <font-awesome-icon icon="fas fa-truck" ></font-awesome-icon>
              </button>
            </div>
          </td>

          <!-- <td class="hidden md:table-cell">
            <div class="flex flex-col items-center gap-1">
              <button
                @click="showSomeModal(EnumPurchaseModalType.OrderPayment)"
                class="btn btn-circle btn-xl"
              >
                <font-awesome-icon icon="fas fa-sack-dollar" ></font-awesome-icon>
              </button>
            </div>
          </td> -->

          <td class="hidden md:table-cell">
            <div class="flex flex-col items-center gap-1">
              <button
                @click="showSomeModal(EnumPurchaseModalType.OrderShippingGuide)"
                class="btn btn-primary btn-circle btn-xl"
              >
                <font-awesome-icon icon="fas fa-file" ></font-awesome-icon>
              </button>

               <button
                @click="showSomeModal(EnumPurchaseModalType.OrderShippingGuide)"
                class="btn btn-error btn-circle btn-xl"
              >
                <font-awesome-icon icon="fas fa-file" ></font-awesome-icon>
              </button>
            </div>
          </td>

        </template>        
        </tr>
      </template>
    </AtlasTableWrapper>
  </AdminLayout>
</template>
