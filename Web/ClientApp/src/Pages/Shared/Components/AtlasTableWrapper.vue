<script setup lang="ts">
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import AtlasCustomNavTool from "./AtlasCustomNavTool.vue";

defineProps<IAtlasCustomTableConfig>();
</script>

<template>
    <div class="bg-base-100 md:shadow-lg">

    <div class="sticky top-16 z-20 ">
      <AtlasCustomNavTool :configs="configs" class="">
        <template #buttonSloSlot>
          <slot name="buttonSlot" ></slot>
        </template>
      </AtlasCustomNavTool>
    </div>

    
      
      <table class="table  ">
        <thead class="text-center text-xl font-bold p-0 ">
          <tr class="bg-base-300">
            <slot name="customTh"></slot>
            <th class="p-0" v-for="header in configs.headersLabels" :key="header">
              <span class="hover:underline hover:cursor-pointer hover:text-black" :class="{ 'hidden lg:table-cell' : header === 'Modelo'}">
                {{ header }}
              </span>
            </th>
    
             <template v-if="configs.headersLabels.length >=2">
               <th class="hidden md:table-cell">Acciones</th>
              </template>
              <template v-else>
                <th class="table-cell">Acciones</th>
              </template>
          </tr>
        </thead>
    
        <tbody class="">
         <slot></slot>
         


        </tbody>
      </table>
    </div>


</template>
