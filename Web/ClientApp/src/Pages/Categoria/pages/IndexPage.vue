<script setup lang="ts">
import IDtoCategoria from "@/Models/Entities/IDtoCategoria";
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import AtlasTableActions from "@/Pages/Shared/Components/AtlasTableActions.vue";
import AtlasTableWrapper from "@/Pages/Shared/Components/AtlasTableWrapper.vue";

const props = defineProps<IAtlasMixedResponse<IDtoCategoria>>();

const tableConfig: IAtlasCustomTableConfig = {
  configs: {
    title: "Categorias",
    resource: "Categoria",
    headersLabels: ["Nombre", "Productos"],
  },
};
</script>

<template>
  <AdminLayout>
    <AtlasTableWrapper v-bind="tableConfig">
      <template v-slot:default>
        <tr v-for="resource in mainResourceCollection" :key="resource.id">
            <td>
                <span class="badge text-white text-xl font-bold p-6 w-full" 
                    :class="{'badge-accent': !resource.color }"
                    :style="`background-color: ${resource.color}; border-color: ${resource.color}`">
                    {{ resource.nombre }}
                  </span>
                  <div class="md:hidden mt-2">
                      <AtlasTableActions v-bind="resource" :resource="tableConfig.configs.resource"></AtlasTableActions>
                  </div>
                  
                  
            </td>
            <td>
                <span class="badge text-xl font-bold w-full" >
                    {{ resource.productosAsociados }}
                </span>
            </td>
            <td class="hidden md:table-cell">
                <AtlasTableActions v-bind="resource" :resource="tableConfig.configs.resource"></AtlasTableActions>
            </td>
        </tr>
      </template>
    </AtlasTableWrapper>
  </AdminLayout>
</template>
