<script setup lang="ts">
import IAtlasCustomTableConfig from '@/Models/Interfaces/IAtlasCustomTableConfig';
import AdminLayout from '@/Pages/admin/layout/AdminLayout.vue';
import AtlasTableWrapper from '@/Pages/Shared/Components/AtlasTableWrapper.vue';

const tableConfig: IAtlasCustomTableConfig = {
  configs: {
    headersLabels: ["Titulo", "Modelo"],
    resource: "venta",
    title: "Ventas",
  },
};

</script>


<template>
    

        <AdminLayout>
            <AtlasTableWrapper v-bind="tableConfig">

            </AtlasTableWrapper>
        </AdminLayout>
</template>