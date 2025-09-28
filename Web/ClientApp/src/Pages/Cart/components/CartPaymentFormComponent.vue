<script setup lang="ts">
import { AtlasEnumInputType } from '@/Models/Enums/AtlasEnumInputType';
import { IAtlasCustomFormConfig } from '@/Models/Interfaces/IAtlasCustomFormConfig';
import AtlasCustomTemplateForm from '@/Pages/Shared/Components/AtlasCustomTemplateForm.vue';
import { ref } from 'vue';
import * as yup from 'yup';
import CartPaymentCardFormComponent from './CartPaymentCardFormComponent.vue';
import CartPaymentTransferFormComponent from './CartPaymentTransferFormComponent.vue';
import CartPaymentPayPalFormComponent from './CartPaymentPayPalFormComponent.vue';


const configs = ref<IAtlasCustomFormConfig>({
    title:"Configurar Direccion",
    resource: "Dir",
    sectionTitle: "Configurar Metodo de Pago",
    customClassTitle: 'text-center text-lg mt-5',
    customClassContainer: 'sm:grid-cols-6',
    formSchema:[
        {
            schema: {metodoPagoId: yup.number().required().label('MetodoPago')},
            config: {
                typeInput: AtlasEnumInputType.select
                ,customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-6'
                ,additionalData:[
                  {value:'Tarjeta de Credito', key:1}
                  ,{value:'Tarjeta de Debito', key:2}
                  ,{value:'Transferencia    ', key:3}
                  ,{value:'PayPal',            key:4}
                ]
             
                
            }
        }
    ]
})

const paymentTypeId = ref<number>(0)

const showSubForms = (data:any) =>{
  paymentTypeId.value = data.data.metodoPagoId

  console.log('locls', data.data.metodoPagoId)
}


</script>

<template>
  <div class="grid grid-cols-1 gap-2 p-4">
      <AtlasCustomTemplateForm @form-ok="showSubForms($event)" :configs="configs"></AtlasCustomTemplateForm>
 
      <div class="pt-5">
        
        <div v-if="paymentTypeId == 1 || paymentTypeId == 2">
          <CartPaymentCardFormComponent @form-ok="$emit('emit-payment', $event)"></CartPaymentCardFormComponent>
        </div>
  
        <div v-if="paymentTypeId == 3">
          <CartPaymentTransferFormComponent @form-ok="$emit('emit-payment', $event)" ></CartPaymentTransferFormComponent>
        </div>
  
        <div v-if="paymentTypeId == 4">
          <CartPaymentPayPalFormComponent @form-ok="$emit('emit-payment', $event)" ></CartPaymentPayPalFormComponent>
        </div>
  
        <div v-if="paymentTypeId == 0">
          <h1>seleccione al menos un metodo de pago</h1>
        </div>
   
      </div>
   </div>

  <div class="flex p-4 gap-2">
    <button class="flex-1 btn btn-info">Aceptar</button>
    <button class="flex-1 btn btn-info">Cancelar</button>
  </div>
</template>
