<script setup lang="ts">
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import * as yup from "yup";
import { IAtlasCustomFormConfig } from "../../../Models/Interfaces/IAtlasCustomFormConfig";
import { ref, computed } from 'vue';
import { IAtlasCustomControl } from "@/Models/Interfaces/IAtlasCustomControl";
import AtlasCustomTemplateForm from "@/Pages/Shared/Components/AtlasCustomTemplateForm.vue";
import { AtlasEnumInputType } from "@/Models/Enums/AtlasEnumInputType";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import IAtlasProducto, { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { useAtlasComposableMapKeyValue } from "@/Models/Composables/AtlasComposableMapKeyValue";
import { router, useForm } from "@inertiajs/vue3";
import Producto from '@/Models/Entities/IAtlasProducto';
import { useAtlasComposableLoadingCallbacks } from "@/Models/Composables/AtlasComposableLoadingCallbacks";

const atlasType = AtlasEnumInputType;
const { mapToKeyValue } = useAtlasComposableMapKeyValue();
const {opts} = useAtlasComposableLoadingCallbacks()
const props = defineProps<IAtlasMixedResponse<IAtlasDtoProducto>>();
  
const ad = mapToKeyValue(props.extras.categorias, "nombre");
console.log("las propps", mapToKeyValue(props.extras.categorias, "nombre"));
  
const formImgIsValid = ref(false);
const formInfIsValid = ref(false);
  
const formImg = ref();
const formInf = ref();

const configs = ref<IAtlasCustomFormConfig>({
  initialValues: props.mainResource,
  title: "Crear producto",
  resource: "producto",
  sectionTitle: "Datos del Producto",
  formSchema: [
    { schema: { nombre: yup.string().required().label("Nombre") } },
    {
      schema: { categoriaId: yup.number().required().label("Categoria") },
      config: { typeInput: atlasType.select, additionalData: ad },
    },
    {
      schema: {
        precioUnitario: yup.number().required().min(1).label("Precio Unitario"),
      },
    },
    {
      schema: {
        precioMayoreo: yup.number().required().min(1).label("Precio Mayoreo"),
      },
    },
    {
      schema: {
        existencia: yup.number().required().min(1).label("Existencia"),
      },
    },
    { schema: { talla: yup.string().label("Talla") } },
    { schema: { color: yup.string() } },
    { schema: { genero: yup.string() } },
    {
      schema: {
        existenciaMinima: yup
          .number()
          .required()
          .min(1)
          .label("Existencia Minima"),
      },
    },
    {
      schema: {
        existenciaMaxima: yup
          .number()
          .required()
          .min(1)
          .label("Existencia Maxima"),
      },
    },
    {
      schema: { descripcion: yup.string().required().label("Descripcion") },
      config: { typeInput: atlasType.area },
    },
  ],
});

const configsI = ref<IAtlasCustomFormConfig>({
  initialValues: props.mainResource?.imagenes,
  title: "Crear producto",
  resource: "producto",
  sectionTitle: "Imagenes del Producto",
  formSchema: [
    {
      schema: { imagenes: yup.string().label("Imagenes") },
      config: { typeInput: atlasType.files },
    },
  ],
});

console.log('xxxxx...........x', props)
const saveIsDisabled = computed ( ( ) =>{
  const id = configs.value.initialValues?.id;
  
  if(!!id)
  return formImgIsValid && formInfIsValid && !props.extras.editable

  return !(formImgIsValid && formInfIsValid).value
})

const formOkInfo = (event: any) => {
  console.log('datos del form', event)
  formInfIsValid.value = true;
  formInf.value = event.data;
  console.log("formInfo", event.color);
};

const formOkImg = (event: any) => {
    console.log('datos del form', event)

  formImgIsValid.value = true;
  formImg.value = event.data
  console.log("formImg", event);
};

const url = computed ( () =>{
  const id = configs.value.initialValues?.id;

  if(!!id){
    return  `/admin/producto/update/${id}`
  }

  return  `/admin/producto/store`
})

console.log( 'sssssssssss', url.value)

const submitForm = ()=>{

 


  if( formInfIsValid.value){

    opts.onStart({})
    const f = { ... formInf.value, ... formImg.value}

    const form = useForm(f)
    
    form.post(url.value,{
      _method: 'post',
      forceFormData: true,
      opts
    })

    console.log('el form final ', f);
  }

}

const cancelForm = () =>{
  router.get('/admin/producto/index', {}, opts)
}
</script>

<template>
  <AdminLayout>
    
    <div class="bg-base-100 md:card md:m-5 " >
      <div class="sm:grid sm:grid-cols-3 mx-2 md:mx-4 gap-6">
        <div class="sm:col-span-2">
          <AtlasCustomTemplateForm :configs="configs" @form-ok="formOkInfo" />
        </div>
        <div>
          <AtlasCustomTemplateForm :configs="configsI" @form-ok="formOkImg" />
        </div>
      </div>
      <div class="flex gap-2 m-2">
        
        <button
          class="btn btn-success flex-1"
          @click="submitForm"
          :disabled="saveIsDisabled"
        >
          Guardar
        </button>
        <button class="btn btn-error flex-1"
          @click="cancelForm"
        >Cerrar</button>
      </div>
    </div>
  </AdminLayout>
</template>
