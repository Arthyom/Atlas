<script setup lang="ts">
import IAtlasMixedResponse from '@/Models/Interfaces/IAtlasMixedResponse';
import AdminLayout from '../layout/AdminLayout.vue';
import { IDtoUsuarioResponse } from '@/Pages/auth/DTOs/IDtoUsuario';
import { useAtlasComposableUserStore } from '../../../Models/Composables/AtlasComposableUserStore';

const prop = defineProps<IAtlasMixedResponse<IDtoUsuarioResponse>>();

const { userInfo, setUserInfo } = useAtlasComposableUserStore()

if(prop.mainResource)
    setUserInfo(prop.mainResource )

</script>

<template>

    <AdminLayout>

        <div class="h-screen"></div>

    </AdminLayout>

</template>