<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import IAtlasCustomTemplateWrapper from "@/Models/Interfaces/IAtlasCustomTemplateWrapper";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import AtlasCustomImageStack from "@/Pages/Shared/Components/AtlasCustomImageStack.vue";
import AtlasTableActions from "@/Pages/Shared/Components/AtlasTableActions.vue";
import AtlasTableWrapper from "@/Pages/Shared/Components/AtlasTableWrapper.vue";
import { usePage } from "@inertiajs/vue3";
import { computed, ref } from "vue";

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
</script>

<template>
  <AdminLayout>
    <AtlasTableWrapper :configs="tableConfig.configs">
      <tr v-for="resource in props.mainResourceCollection">
        <th>
          <label>
            <input type="checkbox" class="checkbox" />
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
              <button class="btn bnt-info">
                <font-awesome-icon icon="fa-solid fa-barcode"></font-awesome-icon>
              </button>
            </div>
          </AtlasTableActions>
        </td>
      </tr>
    </AtlasTableWrapper>
  </AdminLayout>
</template>
