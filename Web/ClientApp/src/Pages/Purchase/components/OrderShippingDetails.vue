<script setup lang="ts">
import AtlasCustomModalControl from '@/Pages/Shared/Components/AtlasCustomModalControl.vue';
import { EnumPurchaseModalType } from '../Enums/ModalType.enum';
import { IPurchaseModalConf } from '../interfaces/IPurchaseModalConf.interface';
import { IAtlasCustomControl } from '../../../Models/Interfaces/IAtlasCustomControl';
import { ref } from 'vue';
import { IAtlasCustomFormConfig } from '@/Models/Interfaces/IAtlasCustomFormConfig';
import * as yup from 'yup';
import AtlasCustomTemplateForm from '@/Pages/Shared/Components/AtlasCustomTemplateForm.vue';
import OrderShippingRates from './Shipping/OrderShippingRates.vue';
import { dataEnviosPerrosShippingRate } from '@/Data/EnviosPerrosShippingRates.data';
import { IApiEPShippingRate } from '@/Models/Interfaces/ExternalApis/EnviosPerros/IEnviosPerros.interface';



  defineProps<IPurchaseModalConf>()

  const formPackageDimsIsValid = ref(false)
  const formPackageDims = ref<IAtlasCustomFormConfig>({
    title:'Datos del Paquete',
    sectionTitle: 'Dimenciones del Paquete',
    customClassTitle: 'text-[22px]',
    customClassContainer: 'sm:grid-cols-4',
    resource: '',
    formSchema: [
        { schema: { largo: yup.number().required().positive().label('').label('Largo') }},
        { schema: { ancho: yup.number().required().positive().label('Anchura') }},
        { schema: { alto: yup.number().required().positive().label('Altura')} },
        { schema:{ peso: yup.number().required().positive().label('Peso')}}
    ]
  });

  const setOkValue = (response: any) =>{
    formPackageDimsIsValid.value = response?.isValid
  }

  const epShippingRates: IApiEPShippingRate[] = dataEnviosPerrosShippingRate
</script>


<template >
    <AtlasCustomModalControl 
    :is-valid-ok="formPackageDimsIsValid"  
    @close-modal = "$emit('close-form', false)"
    >

        <template #title>
            <h1 class="text-xl">Informacion del Envio</h1>
        </template>

        <template #body>
            <AtlasCustomTemplateForm 
              v-if="false"
                @form-ok="setOkValue($event)" 
                :configs="formPackageDims"
            >
            </AtlasCustomTemplateForm>


            <OrderShippingRates v-bind:rates="epShippingRates">

            </OrderShippingRates>
        </template>

    </AtlasCustomModalControl>
</template>