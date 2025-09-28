<script setup lang="ts">
import { AtlasEnumInputType } from '@/Models/Enums/AtlasEnumInputType';
import { IAtlasCustomFormConfig } from '@/Models/Interfaces/IAtlasCustomFormConfig';
import AtlasCustomTemplateForm from '@/Pages/Shared/Components/AtlasCustomTemplateForm.vue';
import { ref } from 'vue';
import * as yup from 'yup';



const configs = ref<IAtlasCustomFormConfig>({
    title:"Configurar Direccion",
    resource: "Dir",
    sectionTitle: "Configurar Direccion",
    customClassTitle: 'text-center text-2lg mt-5',
    customClassContainer: 'sm:grid-cols-6',
    formSchema:[
        {
            schema: {paisId: yup.number().required().label('Pais')},
            config: {
                typeInput: AtlasEnumInputType.select
                ,customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-2'
                ,additionalData:[
                  {value:'México', key:1}
                  ,{value:'Estados Unidos', key:2}
                ]
            }
        },

        {
            schema: {estadoId: yup.number().required().label('Estado')},
            config: {
                typeInput: AtlasEnumInputType.select
                ,customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-2'
                ,additionalData:[
                    {value:'Guanajuato', key:1}
                ]

            }
        },

        {
            schema: {municipioId: yup.number().required().label('Municipio')},
            config: {
                typeInput: AtlasEnumInputType.select
                ,customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-2'
                ,additionalData:[
                    {value:'moroleon', key:1}
                ]

            }
        },

        {
            schema: {coloniaId: yup.number().required().label('Colonia')},
            config: {
                typeInput: AtlasEnumInputType.select
                ,customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-2'
                ,additionalData:[
                    {value:'colonia el cuyo', key:1}
                ]
            }
        },
        
        {
            schema: {direccion: yup.string().required()}
            ,config: {
                customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-4'
            }
        },
        {
            schema: {cp: yup.number().required().label('CP')}
            ,config: {
                customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
            }
        },
        {
            schema: {exterior: yup.number().required().label('#Ext.')}
            ,config: {
                customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
            }
        },
        {
            schema: {interior: yup.number().label('#Int.')}
            ,config:{
                customClassLable: 'text-sm md:text-lg'
                ,customClassError: 'hidden'
            }
        },
        {
            schema: {entreCalles: yup.string().label('Entre Calles')}
            ,config: {
                customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-3'
            }
        },
        {
            schema: {referencias: yup.string().required().label('Referencias')}
            ,config: {
                typeInput: AtlasEnumInputType.area, 
                customClassLable: 'text-sm md:text-lg '
                ,customClassError: 'hidden'
                ,customClassContainer: 'sm:col-span-6'
            }
        },
    ]
})

</script>



<template>
  <div class="p-4">
      <AtlasCustomTemplateForm @form-ok="$emit('emit-address', $event)" :configs="configs"></AtlasCustomTemplateForm>
  </div>


  <div class="flex p-4 gap-2">
    <button class="flex-1 btn btn-info">Aceptar</button>
    <button class="flex-1 btn btn-info">Cancelar</button>
  </div>
</template>
