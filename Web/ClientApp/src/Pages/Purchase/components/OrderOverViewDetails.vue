<script setup lang="ts">
import AtlasCustomModalControl from '@/Pages/Shared/Components/AtlasCustomModalControl.vue';
import { IPurchaseModalConf } from '../interfaces/IPurchaseModalConf.interface';
import { EnumPurchaseModalType } from '../Enums/ModalType.enum';
import { IDtoApiOrders } from '@/Models/Entities/IDtoApiOrder';
import { useAtlasComposableMapKeyValue } from '@/Models/Composables/AtlasComposableMapKeyValue';
import { AtlasDataCountries } from '@/Models/AtlasDataCountries.data';



const mapper = useAtlasComposableMapKeyValue();


const props = defineProps<IDtoApiOrders>();

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

const getCountry = ()=>{
    return countries.find( x => x.key === props.shipping_address.country.code)?.value
}

const getStates = ()=>{
    const codeCountry = props.shipping_address.country.code
    const codeState = props.shipping_address.state.code.toLocaleLowerCase()
    const {states} =  countriesAsObject[codeCountry] 
    const stateName = states.find( (x:any) => x.state_code.toLowerCase() === codeState)
    return stateName.name;
}
</script>




<template >
    <AtlasCustomModalControl @close-modal = "$emit('close-form', false)">

        <template #title>
            <h1>Informacion del Pedido</h1>
        </template>

        <template #body>

            <div class="mb-4">
                <h1 class="font-bold">Propietario</h1>
                <div class="ml-4 flex gap-4">
                    <span>  {{ props.first_name }} {{ props.last_name }}</span>
                    <span>{{ props.email }}</span>
                    <span>{{ props.phone }}</span>
                </div>
            </div>


            <div>
                <h1 class="font-bold">Receptor</h1>
                <div class="ml-4">
                    <div class="mb-2">
                        <p>{{ props.shipping_address.first_name }} {{ props.shipping_address.last_name }}</p>
                        <p>{{ props.shipping_address.phone }}</p>
                    </div>

                    <div class="mb-2">
                        <p>{{ props.shipping_address.address1 }}</p>
                        <p>{{ props.shipping_address.address2 }}</p>
                        <p>{{ props.shipping_address.postal_code }}</p>
                    </div>
    
                    <p>{{ props.shipping_address.city }}, {{ getStates() }}, {{ getCountry() }}</p>
                </div>

            </div>

        </template>

    </AtlasCustomModalControl>
</template>