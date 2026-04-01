<script setup lang="ts">
import IAtlasMixedResponse from '@/Models/Interfaces/IAtlasMixedResponse';
import StoreFrontLayOutPage from '@/Pages/layouts/store-front/StoreFrontLayOutPage.vue';
import { IDtoProducto } from '@/Pages/Producto/DTOs/IDtoProducto';
import ShopProduct from '../components/ShopProduct.vue';
import ShopProductDetail from '../components/ShopProductDetail.vue';

const props = defineProps<IAtlasMixedResponse<IDtoProducto>>();


</script>


<template>

    <StoreFrontLayOutPage>

        <div class="m-2">

            <template v-if="props.mainResource">
                <ShopProductDetail :producto="props.mainResource" ></ShopProductDetail>
            </template>
            <template v-else>
                <p>Producto no encontrado</p>
            </template>

        </div>    




    </StoreFrontLayOutPage>

</template>