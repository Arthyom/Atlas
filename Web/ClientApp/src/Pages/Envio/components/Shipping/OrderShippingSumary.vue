<script setup lang="ts">
import AtlasCustomColapseControl from '@/Pages/Shared/Components/AtlasCustomColapseControl.vue';


</script>


<template>
    <div class="flex flex-col gap-2">

        <AtlasCustomColapseControl :gridCols="'grid-cols-5'" :show-button="true">
            <template #header>
                <h1 class="text-md font-bold text-sm md:text-md flex-1">Paquete</h1>
            </template>
            <template #body>
                <span class="col-span-5 text-left mt-2"> <span class="font-bod block">Empresa</span> {{ 'lorem lorem lorem lorem' }}</span>
                <span class="col-span-5 text-left"> <span class="font-bod block">descripcion:</span> {{ 'lorem lorem lorem lorem' }}</span>
                <span class="col-span-2 sm:col-span-1 "> <span class="font-bol block">profundidad</span> {{ 555.55 }}</span>
                <span class="col-span-2 sm:col-span-1 "> <span class="font-bod block">anchura</span> {{ 555.55 }}</span>
                <span class="col-span-1 sm:col-span-1 "> <span class="font-old block">tipo</span> {{ 'sobre' }}</span>
                <span class="col-span-2 sm:col-span-1 "> <span class="font-bld block">altura</span> {{ 555.55 }}</span>
                <span class="col-span-2 sm:col-span-1 "> <span class="font-old block">peso</span> {{ 555.55 }}</span>
                <div class="mt-2 col-end-6">
                    <button class="btn btn-xs btn-warning ">Editar</button>
                </div>
            </template>
        </AtlasCustomColapseControl>

        <AtlasCustomColapseControl :gridCols="'grid-cols-3'" :show-button="true">
            <template #header>
                <h1 class="text-md font-bold text-sm md:text-md flex-1">Origen</h1>
            </template>
            <template #body>
               <span class="mt-2 col-span-3 text-left"> 
                    <span class="font-bol block ">Direccion</span> 
                    {{ 'Eje Central Lázaro Cárdenas #23 Int. 25, CP: 38800, Colonia: Moroleon centro, Ciudad: Moroleon de México, Estado: Estado de Mexico' }}
                </span>
                <span class=" col-span-3 text-left"> <span class="font-bod block ">Referencias</span> {{ 'lorem lorem lorem lorem' }}</span>             
                <span class="col-span-3 sm:col-span-1 text-left sm:text-center"> <span class="font-old block">Emisor</span> {{ 'Alex Lora'}}</span>
                <span class="col-span-3 sm:col-span-1 text-left sm:text-center"> <span class="font-old block">Email</span> {{ 'ejemplo@gmail.com' }}</span>
                <span class="col-span-3 sm:col-span-1 text-left sm:text-center"> <span class="font-old block">Telefono</span> {{ '2291234567' }}</span>
                <div class="mt-2 col-end-4">
                    <button class="btn btn-xs btn-warning ">Editar</button>
                </div>
            </template>
        </AtlasCustomColapseControl>


        <AtlasCustomColapseControl :gridCols="'grid-cols-3'" >
            <template #header>
                <h1 class="text-md font-bold text-sm md:text-md flex-1">Destino</h1>
            </template>
            <template #body>
               <span class="mt-2 col-span-3 text-left"> 
                    <span class="font-bol block ">Direccion</span> 
                    {{ 'Eje Central Lázaro Cárdenas #23 Int. 25, CP: 38800, Colonia: Moroleon centro, Ciudad: Moroleon de México, Estado: Estado de Mexico' }}
                </span>
                <span class=" col-span-3 text-left"> <span class="font-bod block ">Referencias</span> {{ 'lorem lorem lorem lorem' }}</span>             
                <span class="col-span-3 sm:col-span-1 text-left sm:text-center"> <span class="font-old block">Emisor</span> {{ 'Alex Lora'}}</span>
                <span class="col-span-3 sm:col-span-1 text-left sm:text-center"> <span class="font-old block">Email</span> {{ 'ejemplo@gmail.com' }}</span>
                <span class="col-span-3 sm:col-span-1 text-left sm:text-center"> <span class="font-old block">Telefono</span> {{ '2291234567' }}</span>
            </template>
        </AtlasCustomColapseControl>

    </div>
</template>