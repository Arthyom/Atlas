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
import { ICartDireccion, ICartMetodoPago } from "../interfaces/CartDireccion.interface";

const { products, totalProductos, totalPago } = storeToRefs(useAtlasCartStore());
const { swipeNext, swipePrev, swipeAt, step } = AtlasComposableCustomSwipper("swipper");
const showModal = ref(false);
const form = reactive<{address?:ICartDireccion, payMethod?:ICartMetodoPago}>({})

const setAddress= (addresss: any)=>{
  form.address = addresss.data
}

const setPaymentMethod= (payment: any)=>{

  console.log('paymento,', payment)
  form.payMethod = payment.data
}
</script>

<template>

  <AtlasCustomModalControl v-if="showModal" @close-modal="showModal=$event" @close-ok="useAtlasCartStore().destroyCart()">
    <template #title>
      info
    </template>

    <template #body>
      Realmente desea eliminar el carrito de compras actual?
    </template>
  </AtlasCustomModalControl>
  
  <CartLayoutPage
  @swipe-prev="swipePrev"
  @swipe-next="swipeNext"
  @destroy-cart="showModal=true"
  
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
            >
            </CartButtonSwipperComponent>

            <CartAddressFormComponent @emit-address="setAddress($event)"></CartAddressFormComponent>
          </swiper-slide>

          <swiper-slide>
            <CartButtonSwipperComponent
              :show-next="true"
              :show-prev="true"
              @swipe-next="swipeNext"
              @swipe-prev="swipePrev"
            >
            </CartButtonSwipperComponent>
            <CartPaymentFormComponent @emit-payment="setPaymentMethod($event)"></CartPaymentFormComponent>
          </swiper-slide>

          <swiper-slide>
            <CartButtonSwipperComponent
              :show-prev="true"
              :show-finish="true"
              @swipe-next="swipeNext"
              @swipe-prev="swipePrev"
            >
            </CartButtonSwipperComponent>
            <CartFinishingFormComponent
             @edit-at="swipeAt($event)" 
             :metodo-pago="form.payMethod"
             :direccion="form.address"
             :total="totalPago" 
             :products="products" >
            </CartFinishingFormComponent>
          </swiper-slide>
        </swiper-container>
      </div>
    </div>
  </CartLayoutPage>
</template>
