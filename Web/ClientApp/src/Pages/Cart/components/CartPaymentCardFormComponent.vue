<script setup lang="ts">
import { AtlasEnumInputType } from '@/Models/Enums/AtlasEnumInputType';
import { IAtlasCustomFormConfig } from '@/Models/Interfaces/IAtlasCustomFormConfig';
import AtlasCustomTemplateForm from '@/Pages/Shared/Components/AtlasCustomTemplateForm.vue';
import { ref } from 'vue';
import * as yup from 'yup';

const configs = ref<IAtlasCustomFormConfig>({
  title: "Configurar Direccion",
  resource: "Dir",
  sectionTitle: "Datos de la Tarjeta",
  customClassTitle: "text-center text-lg ",
  customClassContainer: "sm:grid-cols-6 px-15",
  customClassDivider:"hidden",
  formSchema: [
    {
      schema: { titular: yup.string().required().label("Titular") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassContainer: "sm:col-span-6",
        customClassError: "hidden",
        placeHolder:'Nombre del Titular'
      },
    },

    {
      schema: { numero: yup.string().required().max(12).min(12).label("Numero") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-6",
        placeHolder:'1111-2222-3333-4444'
      },
    },

    {
      schema: { vencimiento: yup.string().required().min(5).max(5).label("Vencimiento") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-2",
        placeHolder: 'MM/AA',
        formatFunction: (inp:string)=>{
          if(!!inp){
            switch (inp.length) {
              case 1:
                return inp
              case 2:
                return inp[0]+inp[1]
              case 3: 
                return inp[0]+inp[1]+'/'+(inp[2] !== '/' ? inp[2] : '' )
              case 4: 
                return inp[0]+inp[1]+'/'+inp[3]
              case 5: 
                return inp[0]+inp[1]+'/'+inp[3]+inp[4]
      
            }
          }
        }
      },
    },

    {
      schema: { CVV: yup.string().required().max(3).min(3).label("CVV") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-2",
        placeHolder:'123'
      },
    }
    
  ],
});
</script>

<template>
  <AtlasCustomTemplateForm @form-ok="$emit('form-ok', $event)" :configs="configs"></AtlasCustomTemplateForm>
</template>
