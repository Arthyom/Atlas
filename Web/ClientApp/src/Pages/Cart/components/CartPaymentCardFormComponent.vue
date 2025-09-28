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
        customClassError: "hidden",
        customClassContainer: "sm:col-span-6"
      },
    },

    {
      schema: { numero: yup.string().required().label("Numero") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-6"
      },
    },

    {
      schema: { vencimiento: yup.string().required().label("Vencimiento") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-2"
      },
    },

    {
      schema: { CVV: yup.string().required().label("CVV") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-2"
      },
    }
    
  ],
});
</script>

<template>
  <AtlasCustomTemplateForm @form-ok="$emit('form-ok', $event)" :configs="configs"></AtlasCustomTemplateForm>
</template>
