<script setup lang="ts">
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import AtlasCustomNavTool from "./AtlasCustomNavTool.vue";

defineProps<IAtlasCustomTableConfig>();
</script>

<template>
    <div class="bg-base-100 rounded-lg shadow-lg">
        
        <AtlasCustomNavTool :configs="configs"/>

      <table class="table">
        <thead class="text-center text-xl font-bold">
          <tr class="bg-base-300">
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <th v-for="header in configs.headersLabels" :key="header">
              <span class="hover:underline hover:cursor-pointer hover:text-black">
                {{ header }}
              </span>
            </th>
    
            <th>Acciones</th>
          </tr>
        </thead>
    
        <tbody>
         <slot></slot>
        </tbody>
      </table>
    </div>
</template>
