<script setup lang="ts">
import AtlasInfiniteLoader from '@/Pages/Shared/Components/AtlasInfiniteLoader.vue';
import AdminFooterComponent from '../components/AdminFooterComponent.vue';
import AdminNavBarComponent from '../components/AdminNavBarComponent.vue';
import { useAtlasStoreLoading } from '@/Pages/Shared/store/AtlasStoreLoading';

const vs = useAtlasStoreLoading()

</script>

<template>


<AtlasInfiniteLoader ></AtlasInfiniteLoader>


<AdminNavBarComponent></AdminNavBarComponent>

    <div class="h-full">
        <div class="flex flex-col justify-center   bg-red-500">
            <slot></slot>

        </div>
    </div>


<AdminFooterComponent></AdminFooterComponent>
    
</template>