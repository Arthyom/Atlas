<script setup lang="ts">
import AtlasCustomModalControl from "@/Pages/Shared/Components/AtlasCustomModalControl.vue";
import { EnumPurchaseModalType } from "../Enums/ModalType.enum";
import { IAtlasCustomControl } from "../../../Models/Interfaces/IAtlasCustomControl";
import { reactive, ref } from "vue";
import { IAtlasCustomFormConfig } from "@/Models/Interfaces/IAtlasCustomFormConfig";
import * as yup from "yup";
import AtlasCustomTemplateForm from "@/Pages/Shared/Components/AtlasCustomTemplateForm.vue";
import OrderShippingRates from "./Shipping/OrderShippingRates.vue";
import { dataEnviosPerrosShippingRate } from "@/Data/EnviosPerrosShippingRates.data";
import { AtlasEnumInputType } from "@/Models/Enums/AtlasEnumInputType";
import OrderShippingSumary from "./Shipping/OrderShippingSumary.vue";
import { IPurchaseModalConf } from "../interfaces/IPurchaseModalConf";
import { IDtoEnPeShippingRate } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingRate";
import { IDtoEnvio } from "../interfaces/IDtoEnvio";
import AtlasCustomTemplateFormSm from "@/Pages/Shared/Components/AtlasCustomTemplateFormSm.vue";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";
import { useAtlasComposableCustomFormActions } from "@/Models/Composables/AtlasComposableCustomFormActions";
import { IDtoEnPeShippingPackageSize } from "@/Models/DTOs/APIs/EnPe/IDtoEnPehippingPackageSize";
import { OrderShippingUpdatingEnum } from "../Enums/OrderShippingUpdatingSelecter.enum";

const props = defineProps<IDtoEnvio>();

const packageInfo = ref<IDtoEnPeShippingPackageSize>()
const shippingRate = ref<IDtoEnPeShippingRate>()


const shippingRates: IDtoEnPeShippingRate[] = [
  {
    cost: 45.58,
    currency: "MXN",
    deliveryType: {
      company: "test",
      description: "test",
      feature: "test",
      name: "name",
    },
    packageSize: "2",
    pickup: true,
    title: "title",
  },
];


const formPackageDimsIsValid = ref(false);
const formPackageDims = ref<IAtlasCustomFormConfig>({
  title: "Medidas del Paquete",
  initialValues:props.packageSize,
  sectionTitle: "Medidas del Paquete",
  customClassTitle: "text-[22px]",
  customClassContainer: "",
  resource: "",

  
  formSchema: [
    {
      config: {
        customClassContainer: "col-span-3 md:col-span-1",
      },
      schema: {
        width: yup.number().required().positive().label("").label("Largo"),
      },
    },
    {
      config: {
        customClassContainer: "col-span-3  md:col-span-1",
      },
      schema: { depth: yup.number().required().positive().label("Anchura") },
    },
    {
      config: {
        customClassContainer: "col-span-3  md:col-span-1",
      },
      schema: { height: yup.number().required().positive().label("Altura") },
    },
    {
      config: {
        customClassContainer: "col-span-3  md:col-span-3 lg:col-span-1",
      },
      schema: { weight: yup.number().required().positive().label("Peso") },
    },
    {
      config: {
        customClassContainer: "col-span-3  md:col-span-8z<z lg:col-span-8",
        typeInput: AtlasEnumInputType.text
      },
      schema: { description: yup.string().required().label("Descripcion") },
    },
    {
      schema: {
        type: yup.string().required().label("Tipo de Paquete"),
      },
      config: {
        showControl: true,
        typeInput: AtlasEnumInputType.select,
        // ,customClassLable: 'text-sm md:text-lg '
        customClassError: "hidden",
        customClassContainer: "col-span-3 md:col-span-3 lg:col-span-4",
        additionalData: [
          { value: "Sobre", key: "sobre" },
          { value: "Caja", key: "box" },
        ],
      },
    },
  ],
});

const setPackageValues =  (response: any) => {
  console.log('response from form', response)
  if(response?.isValid){
    formPackageDimsIsValid.value = true;
    packageInfo.value  = response.data;
    updatingTarget.value = OrderShippingUpdatingEnum.UpdatePackage
    return
  }
  formPackageDimsIsValid.value = false;
};

const setShippingRatesValues =  (response: any) => {
  console.log('response from shipping rates component', response)
  if(response){
    formPackageDimsIsValid.value = true;
    shippingRate.value  = response;
    updatingTarget.value = OrderShippingUpdatingEnum.UpdateShippingRate
    return
  }
  formPackageDimsIsValid.value = false;
};

const updatingTarget = ref<OrderShippingUpdatingEnum>();

const updatePackage = async() =>{
  const comp = useAtlasComposableAjaxActions('', 'admin', `paquete/json/${packageInfo.value?.id}`);
  const resp = await comp.sendRequest(packageInfo.value, 'PATCH', `/admin/paquete/json/${packageInfo.value?.id}`);
}

const updateShippingRates = async() =>{
  const comp = useAtlasComposableAjaxActions('', 'admin', `paquete/json/${packageInfo.value?.id}`);
  const resp = await comp.sendRequest(packageInfo.value, 'PATCH', `/admin/paquete/json/${packageInfo.value?.id}`);
}



const updateEnvio = async () =>{

  switch (updatingTarget.value) {
    case OrderShippingUpdatingEnum.UpdatePackage:
      await updatePackage();

    case OrderShippingUpdatingEnum.UpdateShippingRate:
      await updateShippingRates();
    break;



 
  }
}

const epShippingRates: IDtoEnPeShippingRate[] = dataEnviosPerrosShippingRate;
</script>

<template>
  <AtlasCustomModalControl
    :is-valid-ok="formPackageDimsIsValid"
    @close-ok="updateEnvio"
    @close-modal="$emit('close-form', false)"
  >
    <template #title>
      <h1 class="text-xl">Informacion del Envio</h1>
    </template>

    <template #body>
      <div class="carousel w-full">
        <div id="slide1" class="carousel-item flex flex-col w-full">
          <AtlasCustomTemplateFormSm
            v-if="true"
            @form-ok="setPackageValues($event)"
            :configs="formPackageDims"
          >
          </AtlasCustomTemplateFormSm>
          <div
            class=" left-2 right-2  flex  justify-end mt-2"
          >
            <!-- <a href="#slide4" class="btn btn-circle">❮</a> -->
            <a href="#slide2" class="btn btn-circle">❯</a>
          </div>
        </div>

        <div id="slide2" class="carousel-item flex flex-col w-full">
          <OrderShippingRates v-if="true" v-bind:rates="shippingRates" 
          @selected-ok="setShippingRatesValues($event)"
          >
          </OrderShippingRates>
          <div
            class="  left-2 right-2 flex  justify-between mt-2"
          >
            <a href="#slide1" class="btn btn-circle">❮</a>
            <a href="#slide3" class="btn btn-circle">❯</a>
          </div>
        </div>
        <div id="slide3" class="carousel-item flex flex-col w-full">
          <OrderShippingSumary
            v-bind:origen="props.origin"
            v-bind:destino="props.destination"
            v-bind:paquete="props.packageSize"
            v-bind:shipping-rate="shippingRate"
          >
          </OrderShippingSumary>
          <div
            class=" left-2 right-2  flex  justify-start mt-2"
          >
            <a href="#slide2" class="btn btn-circle">❮</a>
            <!-- <a href="#slide4" class="btn btn-circle">❯</a> -->
          </div>
        </div>
      </div>
      <!-- 
      <AtlasCustomTemplateForm
        v-if="false"
        @form-ok="setOkValue($event)"
        :configs="formPackageDims"
      >
      </AtlasCustomTemplateForm> -->

      <!-- <OrderShippingRates v-if="false" v-bind:rates="epShippingRates">
      </OrderShippingRates> -->

      <!-- <OrderShippingSumary
        v-bind:origen="props.origin"
        v-bind:destino="props.destination"
        v-bind:paquete="props.packageSize"
      >
      </OrderShippingSumary> -->
    </template>
  </AtlasCustomModalControl>
</template>
