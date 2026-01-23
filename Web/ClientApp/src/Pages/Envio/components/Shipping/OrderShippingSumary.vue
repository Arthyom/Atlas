<script setup lang="ts">
import { IDtoEnPeShippingPackageSize } from "@/Models/DTOs/APIs/EnPe/IDtoEnPehippingPackageSize";
import { IDtoEnPeShippingDestination } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingDestination";
import { IDtoEnPeShippingOrigin } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingOrigin";
import { IDtoEnPeShippingRate } from "@/Models/DTOs/APIs/EnPe/IDtoEnPeShippingRate";
import AtlasCustomColapseControl from "@/Pages/Shared/Components/AtlasCustomColapseControl.vue";

const props = defineProps<{
  destino: IDtoEnPeShippingDestination;
  origen: IDtoEnPeShippingOrigin;
  paquete: IDtoEnPeShippingPackageSize;
  shippingRate?: IDtoEnPeShippingRate;
}>();

const getDireccionDestino = () => {
  const dst = props.destino;
  const intNum =
    "Int. " + dst.interior_number_dest ? dst.interior_number_dest : "";
  const direccion = `${dst.street_dest} #${dst.outdoor_number_dest} ${intNum}, 
    CP: ${dst.zip_code_dest}, Colonia: ${dst.neighborhood_dest}, Ciudad: ${dst.city_dest}, Estado: ${dst.state_dest}`;
  return direccion;
};

const getDireccionOrigen = () => {
  const org = props.origen;
  const intNum =
    "Int. " + org.interior_number_origin ? org.interior_number_origin : "";
  const direccion = `${org.street_origin} #${org.outdoor_number_origin} ${intNum}, 
    CP: ${org.zip_code_origin}, Colonia: ${org.neighborhood_origin}, Ciudad: ${org.city_origin}, Estado: ${org.state_origin}`;
  return direccion;
};
</script>

<template>
  <div class="flex flex-col gap-2">
    <h2 class="font-bold">Resumen del Envio</h2>

    <AtlasCustomColapseControl :gridCols="'grid-cols-4'" :show-button="true">
      <template #header>
        <h1 class="text-md font-bold text-sm md:text-md flex-1">Paqueteria</h1>
      </template>
      <template #body>
        <template v-if="props.shippingRate">
          <!-- <span class="col-span-5 text-left mt-2"> <span class="font-bod block">Empresa</span> {{ props }}</span> -->
          <span class="col-span-1 text-left">
            <span class="font-bold block">Nombre</span>
            <span class="badge" :class=" props.shippingRate.pickup ? 'badge-success' : 'badge-error' ">
                {{ props.shippingRate?.deliveryType.company }} {{ props.shippingRate?.deliveryType.description }}
            </span>
        </span>
          <span class="col-span- sm:col-span-1">
            <span class="font-bold block">Descripcion</span>
            {{ props.shippingRate?.deliveryType.description }}</span
          >
          <span class="col-span- sm:col-span-1">
            <span class="font-bold block">Duracion</span>
            {{ props.shippingRate?.deliveryType.feature }}</span
          >
          <span class="col-span-1 sm:col-span-1">
            <span class="font-bold block">Costo</span>
            {{ props.shippingRate.cost }}</span
          >
       
         
        </template>

        <template v-else>
          <p>No ha seleccionado el servicio de paqueteria</p>
        </template>
      </template>
    </AtlasCustomColapseControl>

    <AtlasCustomColapseControl :gridCols="'grid-cols-5'" :show-button="true">
      <template #header>
        <h1 class="text-md font-bold text-sm md:text-md flex-1">Paquete</h1>
      </template>
      <template #body>
        <!-- <span class="col-span-5 text-left mt-2"> <span class="font-bod block">Empresa</span> {{ props }}</span> -->
        <span class="col-span-5 text-left">
          <span class="font-bold block">Descripcion</span>
          {{ props.paquete.description }}</span
        >
        <span class="col-span-2 sm:col-span-1">
          <span class="font-bold block">Profundidad</span>
          {{ props.paquete.depth }}</span
        >
        <span class="col-span-2 sm:col-span-1">
          <span class="font-bold block">Anchura</span>
          {{ props.paquete.width }}</span
        >
        <span class="col-span-2 sm:col-span-1">
          <span class="font-bold block">Altura</span>
          {{ props.paquete.height }}</span
        >
        <span class="col-span-2 sm:col-span-1">
          <span class="font-bold block">Peso</span>
          {{ props.paquete.weight }}</span
        >
        <span class="col-span-1 sm:col-span-1">
          <span class="font-bold block">Tipo</span>
          {{ props.paquete.type }}</span
        >
        <div class="mt-2 col-end-6">
          <button class="btn btn-xs btn-warning">Editar</button>
        </div>
      </template>
    </AtlasCustomColapseControl>

    <AtlasCustomColapseControl :gridCols="'grid-cols-3'" :show-button="true">
      <template #header>
        <h1 class="text-md font-bold text-sm md:text-md flex-1">Origen</h1>
      </template>
      <template #body>
        <span class="mt-2 col-span-3 text-left">
          <span class="font-bold block">Direccion</span>
          {{ getDireccionOrigen() }}
        </span>
        <span class="col-span-3 text-left">
          <span class="font-bold block">Referencias</span>
          {{ props.origen.references_origin }}</span
        >
        <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
          <span class="font-bold block">Emisor</span>
          {{ props.origen.name_origin }}
        </span>
        <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
          <span class="font-bold block">Email</span>
          {{ props.origen.email_origin }}</span
        >
        <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
          <span class="font-bold block">Telefono</span>
          {{ props.origen.phone_origin }}</span
        >
        <div class="mt-2 col-end-4">
          <button class="btn btn-xs btn-warning">Editar</button>
        </div>
      </template>
    </AtlasCustomColapseControl>

    <AtlasCustomColapseControl :gridCols="'grid-cols-3'">
      <template #header>
        <h1 class="text-md font-bold text-sm md:text-md flex-1">Destino</h1>
      </template>
      <template #body>
        <span class="mt-2 col-span-3 text-left">
          <span class="font-bold block">Direccion</span>
          {{ getDireccionDestino() }}
        </span>
        <span class="col-span-3 text-left">
          <span class="font-bold block">Referencias</span>
          {{ props.destino.references_dest }}</span
        >
        <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
          <span class="font-bold block">Emisor</span>
          {{ props.destino.name_dest }}</span
        >
        <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
          <span class="font-bold block">Email</span>
          {{ props.destino.email_dest }}</span
        >
        <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
          <span class="font-bold block">Telefono</span>
          {{ props.destino.phone_dest }}</span
        >
      </template>
    </AtlasCustomColapseControl>
  </div>
</template>
