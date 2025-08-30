<script setup lang="ts">
import { IDtoVenta } from "@/Models/Entities/IDtoVenta";
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import AtlasTableWrapper from "@/Pages/Shared/Components/AtlasTableWrapper.vue";
import AtlasTableActions from "@/Pages/Shared/Components/AtlasTableActions.vue";

const tableConfig: IAtlasCustomTableConfig = {
  configs: {
    headersLabels: ["Folio", "Fecha", "Total", "Productos"],
    resource: "venta",
    title: "Ventas",
  },
};

const props = defineProps<IAtlasMixedResponse<IDtoVenta>>();
</script>

<template>
  <AdminLayout>
    <AtlasTableWrapper v-bind="tableConfig">
      <template v-slot:default>
        <tr
          class="text-center"
          v-for="resource in props.mainResourceCollection"
        >
          <td class="hidden md:table-cell">
            {{ resource.folio }}
          </td>
          <td class="hidden md:table-cell">
            {{ resource.createdAt }}
          </td>
          <td class="hidden md:table-cell">
            {{ resource.total }}
          </td>
          <td class="hidden md:table-cell">
            {{ resource.totalProductos }}
          </td>

          <td class="hidden md:table-cell">
            <AtlasTableActions
              :id="resource.id"
              :resource="tableConfig.configs.resource"
            >
              <div class="tooltip" data-tip="Etiqueta">
                <button class="btn bnt-info" @click="">
                  <font-awesome-icon
                    icon="fa-solid fa-barcode"
                  ></font-awesome-icon>
                </button>
              </div>
            </AtlasTableActions>
          </td>

          <td class="md:hidden">
            <h1>hola small</h1>
          </td>
        </tr>
      </template>
    </AtlasTableWrapper>
  </AdminLayout>
</template>
