<script setup lang="ts">
import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { IDtoApiOrders } from "@/Models/Entities/IDtoApiOrder";
import IDtoCategoria from "@/Models/Entities/IDtoCategoria";
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
import { IPurchaseModalConf } from "../interfaces/IPurchaseModalConf.interface";
import OrderOverViewDetails from "../components/OrderOverViewDetails.vue";

// const props = defineProps<IAtlasMixedResponse<IDtoApiOrders>>();

const modalConf = reactive<IPurchaseModalConf>({});

const selectedIndex = ref(0)

const response = ref<IAtlasMixedResponse<IDtoApiOrders>>({
  mainResourceCollection: [
    {
      currency: "mnx",
      email: "aa",
      first_name: "alfredo",
      folio: "1232323ASDSD",
      state: "Created",
      last_name: "lastname",
      notify_url: "",
      phone: "444444444",
      items: [
        {
          id: 1013,
          name: 'test',
          price: 45.33,
          quantity: 2
        },
        {
          id: 1013,
          name: 'test',
          price: 45.33,
          quantity: 2
        },
        {
          id: 1013,
          name: 'test',
          price: 45.33,
          quantity: 2
        },
        {
          id: 1013,
          name: 'test',
          price: 45.33,
          quantity: 2
        },

    ],
      shipping_address: {
        address1: "address 1",
        address2: "address 2",
        city: "ciudad",
        country: {
          code: "MX",
          name: "pais",
        },
        first_name: "first name",
        last_name: "last name",
        phone: "44444444444444",
        postal_code: 3888,
        state: {
          code: "GUA",
        },
      },
    },
  ],
});

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

const showSomeModal = (type: EnumPurchaseModalType) => {
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
  return response.value.mainResourceCollection[index].items;
}

const getMainItemFromResponse = (index:number) =>{
  return response.value.mainResourceCollection[index];
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
    :items="getItemsFromCollection(selectedIndex)"
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
      @close-form="hideForm"
      v-if="checkModalType(EnumPurchaseModalType.OrderShipping)"
    >
    </OrderShippingDetails>
  </template>

  
  <AdminLayout>
    <AtlasTableWrapper v-bind="tableConfig">


      <template v-slot:default>
        <tr
          v-for="(itemResource,i) in response.mainResourceCollection"
          :key="itemResource.folio"
        >
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
                <div class="flex flex-col items-center gap-2">
                  <div class="flex w-full">
                    <div class="mr-2">
                      <label class="">
                        <input
                          type="checkbox"
                          class="checkbox checkbox-info"
                          v-model="itemResource.selected"
                        />
                      </label>
                    </div>
                    <div class="text-xl w-full font-bold">
                      <div class="flex flex-col items-center gap-1">
                        <div class="badge badge-error">
                          {{ itemResource.state }}
                        </div>
                        <h1>{{ itemResource.folio }}</h1>
                      </div>
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
    
                    <button
                      @click="showSomeModal(EnumPurchaseModalType.OrderPayment)"
                      class="btn btn-md btn-info"
                    >
                      <font-awesome-icon icon="fas fa-sack-dollar" class="text-white"></font-awesome-icon>
                    </button>
                  </div>


              </div>
            </div>
          </td>

          <td class="hidden md:table-cell">
            <div class="flex flex-col items-center gap-1">
              <div class="badge badge-error">{{ itemResource.state }}</div>

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

              <h1>{{ itemResource.folio }}</h1>
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

          <td class="hidden md:table-cell">
            <div class="flex flex-col items-center gap-1">
              <button
                @click="showSomeModal(EnumPurchaseModalType.OrderPayment)"
                class="btn btn-circle btn-xl"
              >
                <font-awesome-icon icon="fas fa-sack-dollar" ></font-awesome-icon>
              </button>
            </div>
          </td>
        </tr>
      </template>
    </AtlasTableWrapper>
  </AdminLayout>
</template>
