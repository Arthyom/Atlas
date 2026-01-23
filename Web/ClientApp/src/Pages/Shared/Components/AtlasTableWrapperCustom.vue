<script setup lang="ts">
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import AtlasCustomNavTool from "./AtlasCustomNavTool.vue";
import { config } from "@fortawesome/fontawesome-svg-core";

const props = defineProps<IAtlasCustomTableConfig>();
</script>

<template>
    <div class="bg-base-100  w-full">

    <div v-if="!props.configs.hideHeaders" class="relative top-16 z-20 " >
      <AtlasCustomNavTool :configs="configs" class="">
        <template #buttonSloSlot>
          <slot name="buttonSlot" ></slot>
        </template>
      </AtlasCustomNavTool>
    </div>

    
      
      <table class="table  ">
        <thead class="text-center text-xl font-bold  " v-if="!configs.hideHeaders">
          <tr class="bg-base-300">
            <slot name="customTh"></slot>
            <th class="hidden md:table-cell" v-for="header in configs.headersLabels" :key="header">
              <div class="flex flex-col">
                <!-- <span class="hover:underline hover:cursor-pointer hover:text-black hidden" :class="{ 'hidden lg:table-cell' : header === 'Modelo'}"> -->
                <span class="hover:underline hover:cursor-pointer hover:text-black hidden md:table-cell " >
                  {{ header }}
                </span>

              </div>
            </th>

            <template v-if="!configs.hideActions">
              <template v-if="configs.headersLabels.length >=2">
                <th class="hidden md:table-cell">Acciones</th>
               </template>
               <template v-else>
                 <th class="table-cell">Acciones</th>
               </template>
            </template>
    
          </tr>
        </thead>
    
        <tbody class="">
         <slot></slot>
         


        </tbody>
      </table>
    </div>


</template>
