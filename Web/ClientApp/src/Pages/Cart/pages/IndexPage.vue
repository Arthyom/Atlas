<script setup lang="ts">
import StoreFrontLayOutPage from "@/Pages/layouts/store-front/StoreFrontLayOutPage.vue";
import { AtlasComposableCustomSwipper } from "@/Models/Composables/AtlasComposableCustomSwipper";
import AtlasCustomProductControl from "@/Pages/Shared/Components/AtlasCustomProductControl.vue";
import { useAtlasCartStore } from "@/Pages/Shared/store/AtlasCartStore";
import { storeToRefs } from "pinia";
import CartLayoutPage from "../layout/CartLayoutPage.vue";
import CartPaymentFormComponent from "../components/CartPaymentFormComponent.vue";
import CartFinishingFormComponent from "../components/CartFinishingFormComponent.vue";
import CartAddressFormComponent from "../components/CartAddressFormComponent.vue";
import CartButtonSwipperComponent from "../components/CartButtonSwipperComponent.vue";
import AtlasCustomModalControl from "@/Pages/Shared/Components/AtlasCustomModalControl.vue";
import { reactive, ref } from "vue";
import {
  ICartDireccion,
  ICartMetodoPago,
} from "../interfaces/CartDireccion.interface";
import { Link, router } from "@inertiajs/vue3";
import CartPaymentFormOwnerComponent from "../components/CartPaymentFormOwnerComponent.vue";
import { ICartPropietario } from '../interfaces/CartDireccion.interface';
import { IAtlasCartPaymentForm } from "@/Models/Entities/IAtlasCartPaymentForm";
import { AtlasHelperProducto } from "@/Models/Helpers/AtlasHelper";
import axios from "axios";
import { useAtlasComposableCustomFormActions } from "@/Models/Composables/AtlasComposableCustomFormActions";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";
import { IDtoExtApiCountryResponse } from "@/Models/Interfaces/ExternalApis/CountryInfo/Country.interface";
import AtlasInfiniteLoader from "@/Pages/Shared/Components/AtlasInfiniteLoader.vue";

const confs = [
  {label:'Productos', fun: (step: number) => step == 1 || step > 1},
  {label: 'Propietario', fun: (step:number) => step >= 2},
  {label: 'Direccion', fun: (step:number) => step >= 3 },
  {label:'Pago', fun: (step: number) => step >= 4}
]

const fetcher = useAtlasComposableAjaxActions<IDtoExtApiCountryResponse> ('', '', 'https://countriesnow.space/api/v0.1/countries/states');



const { products, totalProductos, totalPago } = storeToRefs(
  useAtlasCartStore()
);
const { swipeNext, swipePrev, swipeAt, step } =
  AtlasComposableCustomSwipper("swipper");
const showModal = ref(false);
const form = reactive<IAtlasCartPaymentForm>({});

const setAddress = (addresss: any) => {
  console.log("adreeeeess", addresss);
  form.address = addresss.data;
};

const setPaymentMethod = (payment: any) => {
  console.log("paymento,", payment);
  form.payMethod = payment.data;
};

const setOwner = (owner: any) =>{
    console.log("emit,", owner);

  form.owner = owner.data
}

const closeCart = () => {
  useAtlasCartStore().destroyCart();
  router.get("/store/shop/index");
};


const showOkModal = ref(false)
const showErrModal = ref(false)
const response = ref<any>()

const onFinishForm = async (event: any) =>{

  console.log('eeeee',event)
  form.productos = products.value
  form.totalProductos = totalProductos.value
  form.totalPago = totalPago.value

  const formMapped = AtlasHelperProducto.mapToApiOrder(form)

  const s =  useAtlasComposableCustomFormActions('order', false, null, null,  '/store/order/json/save' )

  

  response.value = await s.submitCustomAjaxmWithData(formMapped)

  if(response.value.statusText = 'OK'){
    response.value = response.value.data.mainResource
    showOkModal.value = true
  }
  else{
    showErrModal.value = true
  }


  console.log('reess' ,  response.value)


}
</script>

<template>
  <AtlasCustomModalControl
    v-if="showModal"
    @close-modal="showModal = $event"
    @close-ok="closeCart"
  >
    <template #title> info </template>

    <template #body>
      Realmente desea eliminar el carrito de compras actual?
    </template>
  </AtlasCustomModalControl>


  <AtlasCustomModalControl
  v-if="showOkModal"
  >
  <template #title>Compra Ok</template>
  <template #body>
    <div class="w-full h-[490px]">
      <iframe class="w-full h-full" :src="response.pay_link"></iframe>
    </div>
  </template>
  </AtlasCustomModalControl>

  <AtlasCustomModalControl v-if="showErrModal">
    <template #title>Error</template>
    <template #body>
      there are some error
    </template>
  </AtlasCustomModalControl>

  <AtlasInfiniteLoader></AtlasInfiniteLoader>

  <CartLayoutPage
    :configs="confs"
    @swipe-prev="swipePrev"
    @swipe-next="swipeNext"
    @destroy-cart="showModal = true"
    :step="step"
    :total-pago="totalPago"
    :total-productos="totalProductos"
  >
    <div class="flex flex-col w-full">
      <div>
        <swiper-container
          ref="swipper"
          class="w-full"
          slides-per-view="1"
          speed="500"
          css-mode="true"
        >
          <swiper-slide>
            <CartButtonSwipperComponent
              :show-next="true"
              @swipe-next="swipeNext"
            ></CartButtonSwipperComponent>
            <div class="grid grid-cols-2 md:grid-cols-3 gap-2">
              <template v-for="p in products">
                <AtlasCustomProductControl
                  v-bind="p"
                ></AtlasCustomProductControl>
              </template>
            </div>
          </swiper-slide>

          <swiper-slide>
            <CartButtonSwipperComponent
              :show-next="true"
              :show-prev="true"
              @swipe-next="swipeNext"
              @swipe-prev="swipePrev"
            ></CartButtonSwipperComponent>
                <CartPaymentFormOwnerComponent @emit-owner="setOwner($event)">

                </CartPaymentFormOwnerComponent>
          </swiper-slide>

          <swiper-slide>
            <CartButtonSwipperComponent
              :show-next="true"
              :show-prev="true"
              @swipe-next="swipeNext"
              @swipe-prev="swipePrev"
            >
            </CartButtonSwipperComponent>

            <CartAddressFormComponent
              @emit-address="setAddress($event)"
            ></CartAddressFormComponent>
          </swiper-slide>

          <!-- <swiper-slide>
            <CartButtonSwipperComponent
              :show-next="true"
              :show-prev="true"
              @swipe-next="swipeNext"
              @swipe-prev="swipePrev"
            >
            </CartButtonSwipperComponent>
            <CartPaymentFormComponent
              @emit-payment="setPaymentMethod($event)"
            ></CartPaymentFormComponent>
          </swiper-slide> -->

          <swiper-slide>
            <CartButtonSwipperComponent
              :show-prev="true"
              :show-finish="true"
              @swipe-next="swipeNext"
              @swipe-prev="swipePrev"
              @finishing="onFinishForm($event)"
            >
            </CartButtonSwipperComponent>
            <CartFinishingFormComponent
              @edit-at="swipeAt($event)"

              :metodo-pago="form.payMethod"
              :direccion="form.address"
              :propietario="form.owner"
              :total="totalPago"
              :products="products"
            >
            </CartFinishingFormComponent>
          </swiper-slide>
        </swiper-container>
      </div>
    </div>
  </CartLayoutPage>
</template>
