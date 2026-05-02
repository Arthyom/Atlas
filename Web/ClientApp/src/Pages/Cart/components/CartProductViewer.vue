<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IDtoProducto } from "@/Pages/Producto/DTOs/IDtoProducto";
import { useAtlasCartStore } from "@/Pages/Shared/store/AtlasCartStore";

const props = defineProps<IDtoProducto>();

const { getFirstFileForProductoAnonimous } = useAtlasComposableUseFilesFetcher();

const { increase, decrease, restore, exclude } = useAtlasCartStore();
</script>

<template>
    <div class="flex flex-col py-2 justify-center">
        <div class="divider m-0 shrink-0"></div> 
        <div class="flex relative">
            <div class="absolute z-10 left-10">
                <button
                    :class="{
                        'btn-error': props.selected,
                        'btn-success': !props.selected,
                    }"
                    class="btn btn-sm md:btn-sm lg:btn-md btn-circle items-center"
                >
                    {{ props.cantidad }}
                </button>
            </div>

            <div class="flex w-full justify-center">
                <div class="avatar flex justify-center">
                    <div class="w-36 rounded-full">
                        <img :src="getFirstFileForProductoAnonimous(props)" />
                    </div>
                </div>
            </div>
        </div>

        <div class="join justify-center" v-if="!props.selected">
            <button
                @click="increase(props)"
                class="btn btn-sm join-item rounded-l-full">
                        <font-awesome-icon icon="fas fa-plus" size="xl" />
                    </button>
            <button
                @click="decrease(props)"
                class="btn btn-sm join-item rounded-r-full">
                    <font-awesome-icon icon="fas fa-minus" size="xl" />
            </button>

            <button 
                @click="exclude(props)" 
                class="btn btn-sm join-item rounded-full ml-2">
                    <font-awesome-icon icon="fas fa-trash" size="lg" />
            </button>
        </div>

        <div v-else class="flex justify-center">
            <button @click="restore(props)" class="btn btn-xs btn-circle ml-2">
                <font-awesome-icon icon="fas fa-circle" size="xs" />
            </button>
        </div>
    </div>
</template>
