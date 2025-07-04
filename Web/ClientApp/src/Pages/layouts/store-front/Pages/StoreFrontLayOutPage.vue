<script setup lang="ts">
import StoreFrontFooterComponent from '../components/StoreFrontFooterComponent.vue';
import StoreFrontNavBarComponent from '../components/StoreFrontNavBarComponent.vue';

</script>


<template>
    <div class="h-screen flex flex-col bg-red-s400">
        
        <StoreFrontNavBarComponent></StoreFrontNavBarComponent>
        <div class="flex-1 m-10 ">
            <slot></slot>
        </div>
        <StoreFrontFooterComponent></StoreFrontFooterComponent>
    </div>
</template>