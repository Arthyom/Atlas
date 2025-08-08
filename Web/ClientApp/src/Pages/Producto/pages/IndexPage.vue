<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { useAtlasComposableLoadingCallbacks } from "@/Models/Composables/AtlasComposableLoadingCallbacks";
import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { AtlasHelperProducto } from "@/Models/Helpers/AtlasHelper";
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import IAtlasCustomTemplateWrapper from "@/Models/Interfaces/IAtlasCustomTemplateWrapper";
import { IAtlasKeyValue } from "@/Models/Interfaces/IAtlasKeyValue";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import AtlasCustomImageStack from "@/Pages/Shared/Components/AtlasCustomImageStack.vue";
import AtlasTableActions from "@/Pages/Shared/Components/AtlasTableActions.vue";
import AtlasTableWrapper from "@/Pages/Shared/Components/AtlasTableWrapper.vue";
import {  useForm, usePage } from "@inertiajs/vue3";
import axios from "axios";
import { stringify } from "postcss";
import { computed, InputTypeHTMLAttribute, ref, h } from 'vue';
    import { saveAs } from 'file-saver';


const areAllChecked = ref<boolean>(false)
const props = defineProps<IAtlasMixedResponse<IAtlasDtoProducto>>();

const { getFirstFileForProducto, noFile } = useAtlasComposableUseFilesFetcher();

console.log("ssssss", props);
const tableConfig: IAtlasCustomTableConfig = {
  configs: {
    headersLabels: ["Titulo", "Modelo", "Precios", "Existencia"],
    resource: "producto",
    title: "Listado de productos",
  },
};

const mode = ref("admin");


const toggleProducts = () =>{
  // const {checked} = (event.target as HTMLInputElement);

  if(props.mainResource)
    props.mainResource.selected = areAllChecked.value;

  props.mainResourceCollection.forEach( x  =>  x.selected = areAllChecked.value);  
}

const cleanSelected = () =>{
  areAllChecked.value = false  
  props.mainResourceCollection.forEach( x  =>  x.selected = areAllChecked.value);  
    
}

const createBarCodes = async() =>{

  const {opts} = useAtlasComposableLoadingCallbacks();

  if(!props.mainResourceCollection.find( x => x.selected )) {
    alert('no codes selected');
    return
  }

  if(!props.mainResourceCollection) return;
  const keyValueProductsMapped = AtlasHelperProducto.getSelectedProducts(props.mainResourceCollection);
  const form = useForm( {items: keyValueProductsMapped} )
  opts.onStart({})

  try {

    const response = await axios.post('/admin/producto/barcode', {items: keyValueProductsMapped}, {responseType: 'blob'});

    
     const url = window.URL.createObjectURL(new Blob([response.data], {type: 'application/pdf'}) );

     window.open(url, "_blank")

     URL.revokeObjectURL(url);
    
  } catch (error) {
    opts.onError({});
    alert('eror')
  }
  finally{
    opts.onFinish({})
    cleanSelected()
  }


  
}
</script>

<template>
  <AdminLayout>
    <AtlasTableWrapper :configs="tableConfig.configs"  >

      <template v-slot:customTh>
        <th>
          <label>
            <input type="checkbox" class="checkbox"  @change="toggleProducts" v-model="areAllChecked"/>
          </label>
        </th>
      </template>
      
      <template v-slot:buttonSlot>
        <button class="btn btn-ghost btn-success  avatar mr-4"  @click="createBarCodes">
          <font-awesome-icon icon="fas fa-barcode"></font-awesome-icon>
        </button>
      </template>

      <template v-slot:default>
        <tr v-for="resource in props.mainResourceCollection">
          <th>
            <label>
              <input type="checkbox" class="checkbox"  v-model="resource.selected"/>
            </label>
          </th>
  
          <td class="">
            <div class="flex items-center justify-center gap-3">
              <div class="avatar">
                <div class="mask mask-squircle h-35 w-35">
                  <img
                    :src="getFirstFileForProducto(resource, mode)"
                    alt="Avatar Tailwind CSS Component"
                  />
                </div>
              </div>
              <div>
                <div class="font-bold">{{ resource.nombre }}</div>
                <span class="badge badge-accent text-sm opacity-50">{{
                  resource.categoria
                }}</span>
              </div>
            </div>
          </td>
  
          <td class="">
            <AtlasCustomImageStack v-bind="resource" />
          </td>
  
          <td>
            <div class="flex justify-center gap-2">
              <div class="tooltip" data-tip="Unitario">
                <span class="badge badge-info">
                  {{ resource.precioUnitario }}</span
                >
              </div>
              <div class="tooltip" data-tip="Mayoreo">
                <span class="badge badge-success">{{
                  resource.precioMayoreo
                }}</span>
              </div>
            </div>
          </td>
          <td>
            <div class="flex justify-center gap-2">
              <div class="tooltip" data-tip="Minima">
                <span class="badge badge-error">
                  {{ resource.existenciaMinima }}</span
                >
              </div>
              <div class="tooltip" data-tip="Actual">
                <span class="badge badge-neutral">{{ resource.existencia }}</span>
              </div>
              <div class="tooltip" data-tip="Maxima">
                <span class="badge badge-success">{{
                  resource.existenciaMaxima
                }}</span>
              </div>
            </div>
          </td>
          <td>
            <AtlasTableActions :id="resource.id">
              <div class="tooltip" data-tip="Etiqueta">
                <button class="btn bnt-info"  @click="resource.selected = true; createBarCodes()">
                  <font-awesome-icon icon="fa-solid fa-barcode"></font-awesome-icon>
                </button>
              </div>
            </AtlasTableActions>
          </td>
        </tr>
      </template>

     

      
    </AtlasTableWrapper>
  </AdminLayout>
</template>
