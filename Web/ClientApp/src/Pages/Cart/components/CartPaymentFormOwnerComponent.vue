<script setup lang="ts">
import { AtlasEnumInputType } from '@/Models/Enums/AtlasEnumInputType';
import { IAtlasCustomFormConfig } from '@/Models/Interfaces/IAtlasCustomFormConfig';
import AtlasCustomTemplateForm from '@/Pages/Shared/Components/AtlasCustomTemplateForm.vue';
import { ref } from 'vue';
import * as yup from 'yup';


const configs = ref<IAtlasCustomFormConfig>({
    title: "Configurar Propietario",
    resource: "Dir",
    sectionTitle: "Configurar Propietario",
    customClassTitle: "text-center text-lg ",
    customClassContainer: "sm:grid-cols-6 px-10",
    customClassDivider:"hidden",
    formSchema: [

        {
            schema: { nombre: yup.string().required().label('Nombre') },
            config: {
                customClassLable: "text-sm md:text-lg ",
                customClassContainer: "sm:col-span-6",
                placeHolder: 'Nombre del Propietario',
            }
        },

        {
            schema: { apellidoP: yup.string().required().label('Apellido Paterno') },
            config:{
                customClassLable: "text-sm md:text-lg ",
                customClassContainer: "sm:col-span-6",
                placeHolder: 'Apellido Paterno'
            }
        },

        {
            schema: { apellidoM: yup.string().label('Apellido Materno') },
            config:{
                customClassLable: "text-sm md:text-lg ",
                customClassContainer: "sm:col-span-6",
                placeHolder: 'Apellido Matrno'
            }
        },

        {
            schema: { email: yup.string().required().label('Correo Electronico').email() },
            config:{
                customClassLable: "text-sm md:text-lg ",
                customClassContainer: "sm:col-span-6",
                placeHolder: 'ejemplo@expl.com'
            }
        },

        {
            schema: { telefono: yup.string().required().label('Telefono/Celular') },
            config:{
                customClassLable: "text-sm md:text-lg ",
                customClassContainer: "sm:col-span-6",
                placeHolder: '111-222-33-44'
            }
        },

        

    ]
})


</script>


<template>
        <AtlasCustomTemplateForm @form-ok="$emit('emit-owner', $event)" :configs="configs"></AtlasCustomTemplateForm>
</template>