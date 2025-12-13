<script setup lang="ts">
import AtlasCustomModalControl from '@/Pages/Shared/Components/AtlasCustomModalControl.vue';
import { EnumPurchaseModalType } from '../Enums/ModalType.enum';
import { IPurchaseModalConf } from '../interfaces/IPurchaseModalConf.interface';
import { IAtlasCustomControl } from '../../../Models/Interfaces/IAtlasCustomControl';
import { reactive, ref } from 'vue';
import { IAtlasCustomFormConfig } from '@/Models/Interfaces/IAtlasCustomFormConfig';
import * as yup from 'yup';
import AtlasCustomTemplateForm from '@/Pages/Shared/Components/AtlasCustomTemplateForm.vue';
import OrderShippingRates from './Shipping/OrderShippingRates.vue';
import { dataEnviosPerrosShippingRate } from '@/Data/EnviosPerrosShippingRates.data';
import { IApiEPShippingRate } from '@/Models/Interfaces/ExternalApis/EnviosPerros/IEnviosPerros.interface';
import { AtlasEnumInputType } from '@/Models/Enums/AtlasEnumInputType';
import OrderShippingSumary from './Shipping/OrderShippingSumary.vue';
import { IApiEPShippingOrder } from '@/Models/Interfaces/ExternalApis/EnviosPerros/IEnviosPerrosShipping.interface';



  const props = defineProps<IPurchaseModalConf>()



  const formPackageDimsIsValid = ref(false)
  const formPackageDims = ref<IAtlasCustomFormConfig>({
    title:'Datos del Paquete',
    sectionTitle: 'Dimenciones del Paquete',
    customClassTitle: 'text-[22px]',
    customClassContainer: '',
    resource: '',
    formSchema: [
      { 
        config:{
          customClassContainer:'col-span-3 md:col-span-1',
        },
        schema: { largo: yup.number().required().positive().label('').label('Largo') }
      },
      { 
         config:{
          customClassContainer:'col-span-3  md:col-span-1',
        },
        schema: { ancho: yup.number().required().positive().label('Anchura') }
      },
      { 
         config:{
          customClassContainer:'col-span-3  md:col-span-1',
        },
        schema: { alto: yup.number().required().positive().label('Altura')} 
      },
      { 
         config:{
          customClassContainer:'col-span-3  md:col-span-3 lg:col-span-1',
        },
        schema:{ peso: yup.number().required().positive().label('Peso')}
      },
      {
        schema: {metodoPagoId: yup.number().required().label('Tipo de Paquete')},
            config: {
                showControl: true,
                typeInput: AtlasEnumInputType.select
                // ,customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'col-span-3 md:col-span-3 lg:col-span-4'
                ,additionalData:[
                  {value:'Sobre',key:1},
                  {value:'Caja', key:2}
                ]
            }
          }
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


            <OrderShippingRates 
            v-if="false"
            v-bind:rates="epShippingRates"
            >
            </OrderShippingRates>


            
            <OrderShippingSumary>

            </OrderShippingSumary>


        </template>

    </AtlasCustomModalControl>
</template>