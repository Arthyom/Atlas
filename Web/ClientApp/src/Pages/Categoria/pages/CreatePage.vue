<script setup lang="ts">
import { useAtlasComposableFormActions } from "@/Models/Composables/AtlasComposableFormActions";
import IDtoCategoria from "@/Models/Entities/IDtoCategoria";
import { AtlasEnumInputType } from "@/Models/Enums/AtlasEnumInputType";
import { IAtlasCustomFormConfig } from "@/Models/Interfaces/IAtlasCustomFormConfig";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import AtlasCustomTemplateForm from "@/Pages/Shared/Components/AtlasCustomTemplateForm.vue";
import {  ref } from 'vue';
import * as yup from "yup";

const {cancelForm, submitForm,  isSaveEnabled, setFormValues, setProps, pickedColor, setFormPaths} =   useAtlasComposableFormActions() 
const atlTypes = AtlasEnumInputType;
const props = defineProps<IAtlasMixedResponse<IDtoCategoria>>();

setProps(props)
setFormPaths('categoria')


const formConfig = ref<IAtlasCustomFormConfig>({  
  title: "Crear producto",
  resource: "producto",
  sectionTitle: "Datos de la Categoria",
  initialValues: props.mainResource,
  formSchema: [
    { schema: { nombre: yup.string().required().label("Nombre") }, config: {} },
    { schema: { codigo: yup.string().required().label("Codigo") }, config: {} },
    {
      schema: { color: yup.string().required().label("Color") },
      config: { typeInput: atlTypes.color },
    },
    {
      schema: { descripcion: yup.string().required().label("Descripcion") },
      config: { typeInput: atlTypes.area },
    }
  ],
});

</script>

<template>
  <AdminLayout>
    <AtlasCustomTemplateForm @form-ok="setFormValues" :configs="formConfig">

      <div class="flex flex-col items-center justify-center  w-full p-10">
        <div>
          <button class="btn mb-4" :style="`background-color: ${pickedColor}`">Ejemplo</button>
        </div>
        <div class="avatar border-accent">
          <div class="avatar-group bg-blck w-full">
            <div class="avatar" :style="`border-color: ${pickedColor}`">
              <div class="w-20 md:w-30 lg:w-42">
                <img
                  class=""
                  :src="'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSxQ8J-kX5_57pZMOKjeaVZV6qitTqHPMszkw&s'"
                />
              </div>
            </div>
          </div>
        </div>

      </div>

      <template v-slot:buttons>
        <div class="flex gap-2 m-4">
          <button :disabled="!isSaveEnabled" class="btn btn-success flex-1"  @click="submitForm()">Guardar</button>
          <button class="btn btn-error flex-1" @click="cancelForm()">Cerrar</button>
        </div>
      </template>
    </AtlasCustomTemplateForm>

  </AdminLayout>
</template>
