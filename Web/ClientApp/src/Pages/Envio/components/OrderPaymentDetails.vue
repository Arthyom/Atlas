<script setup lang="ts">
import AtlasCustomModalControl from '@/Pages/Shared/Components/AtlasCustomModalControl.vue';
import { EnumPurchaseModalType } from '../Enums/ModalType.enum';
import { IPurchaseModalConf } from '../interfaces/IPurchaseModalConf.interface';


</script>


<template >
    <AtlasCustomModalControl  @close-modal = "$emit('close-form', false)">


        <template #title>
            <h1>Informacion del Pago</h1>
        </template>

        <template #body>
            <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Blanditiis maiores cupiditate soluta laudantium iusto iste ab, perspiciatis cum, fuga nihil vero a magni facilis. Earum quia nihil tempore maiores modi.</p>
        </template>

    </AtlasCustomModalControl>
</template>