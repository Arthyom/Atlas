<script setup lang="ts">
import AtlasCustomModalControl from "@/Pages/Shared/Components/AtlasCustomModalControl.vue";
import { EnumPurchaseModalType } from "../Enums/ModalType.enum";
import { useAtlasComposableMapKeyValue } from "@/Models/Composables/AtlasComposableMapKeyValue";
import { AtlasDataCountries } from "@/Models/AtlasDataCountries.data";
import { IDtoOrden } from "@/Models/DTOs/IDtoOrden";
import { IDtoOrder } from "@/Pages/Shop/pages/IDtoOrder";
import { IDtoEnvio } from "../interfaces/IDtoEnvio";
import AtlasCustomColapseControl from "@/Pages/Shared/Components/AtlasCustomColapseControl.vue";

const mapper = useAtlasComposableMapKeyValue();

const props = defineProps<IDtoEnvio>();

console.log("las props en el overview ", props);

const countries = mapper.mapToKeyValueWithId(
  AtlasDataCountries,
  "name",
  "iso2"
);
const countriesAsObject = mapper.mapToObjectFromArray(
  AtlasDataCountries,
  "iso2",
  "states"
) as any;

const getCountry = () => {
  return countries.find((x) => x.key === "MX")?.value;
};

const getDireccionDestino = () => {
  const org = props.origin;
  const intNum =
    "Int. " + org.interior_number_origin ? org.interior_number_origin : "";
  const direccion = `${org.street_origin} #${org.outdoor_number_origin} ${intNum}, 
    CP: ${org.zip_code_origin}, Colonia: ${org.neighborhood_origin}, Ciudad: ${org.city_origin}, Estado: ${org.state_origin}`;
  return direccion;
};

// const getStates = ()=>{
//     const codeCountry = props.shipping_address.country.code
//     const codeState = props.shipping_address.state.code.toLocaleLowerCase()
//     const {states} =  countriesAsObject[codeCountry]
//     const stateName = states.find( (x:any) => x.state_code.toLowerCase() === codeState)
//     return stateName.name;
// }
</script>

<template>
  <AtlasCustomModalControl @close-modal="$emit('close-form', false)">
    <template #title>
      <h1 class="text-center">Informacion del Pedido</h1>
    </template>

    <template #body>
      <div class="grid grid-cols-1 gap-3">
        <!-- <div class="mb-4">
                    <h1 class="font-bold">Propietario</h1>
                    <div class="ml-4 flex gap-4">
                        <span>  {{ props.origin.name_origin }} -->
        <!-- {{ props.origin. }} -->
        <!-- </span>
                        <span>{{ props.origin.email_origin }}</span>
                        <span>{{ props.origin.phone_origin}}</span>
                    </div>
                </div> -->

        <!-- <div>
                    <h1 class="font-bold">Receptor</h1>
                    <div class="ml-4">
                        <div class="mb-2">
                            <p>{{ props.destination.name_dest }} </p>
                            <p>{{ props.destination.phone_dest }}</p>
                            <p>{{ props.destination.email_dest }}</p>
                        </div>
    
                        <div class="mb-2">
                            <p>
                                {{ props.destination.street_dest}}
                                {{ props.destination.outdoor_number_dest }}
                                {{ props.destination.interior_number_dest }}
                                {{ props.destination.neighborhood_dest }}
                                {{ props.destination.zip_code_dest }}
                            </p> -->
        <!-- <p>{{ props.shipping_address.address2 }}</p> -->
        <!-- <p>{{ props.destination.references_dest}}</p>
                        </div>
        
                        <p>{{ props.destination.city_dest }}, {{ props.destination.state_dest }}, {{  }}</p>
                    </div>
    
                </div> -->
                <AtlasCustomColapseControl :gridCols="'grid-cols-3'">
                  <template #header>
                    <h1 class="text-md font-bold text-sm md:text-md flex-1">
                      Propietario
                    </h1>
                  </template>
                  <template #body>
                    <span class="mt-2 col-span-3 text-left">
                      {{ props.origin.name_origin }} {{ props.origin.phone_origin }} {{ props.origin.email_origin }}
                    </span>
                    
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
                      {{ props.origin.references_origin }}</span
                    >
                    <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
                      <span class="font-bold block">Emisor</span>
                      {{ props.origin.name_origin }}</span
                    >
                    <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
                      <span class="font-bold block">Email</span>
                      {{ props.origin.email_origin }}</span
                    >
                    <span class="col-span-3 sm:col-span-1 text-left sm:text-center">
                      <span class="font-bold block">Telefono</span>
                      {{ props.origin.phone_origin }}</span
                    >
                  </template>
                </AtlasCustomColapseControl>
      </div>


    </template>
  </AtlasCustomModalControl>
</template>
