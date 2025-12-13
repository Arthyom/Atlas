<script setup lang="jsx">
    defineProps({
        gridCols: {
            type: String,
            default: 'grid-cols-2',
            optional: true
        },
        showButton:{
            type: Boolean,
            default: false,
            optional: true
        }
    });
</script>


<template>

    <div class="collapse border-1 collapse-arrow border-black rounded-sm ">

            <input type="checkbox" class="peer" />

            <div class="collapse-title flex gap-4 bg-base-300">
                <slot name="header">
                </slot>
            </div>
            <div class=" collapse-content grid  text-xs md:text-md text-center gap-2" :class="gridCols">
                <slot name="body">
                </slot>
            </div>

    </div>

</template>