<script setup lang="ts">
import { Link, router } from '@inertiajs/vue3';
import { useAtlasStoreLoading } from '../store/AtlasStoreLoading';
import { number } from 'yup';
import { useAtlasComposableLoadingCallbacks } from '@/Models/Composables/AtlasComposableLoadingCallbacks';

const props = defineProps<{id: number}>()

const {opts} = useAtlasComposableLoadingCallbacks()

const goTo = (target: string) =>{

  opts.onStart({});

  router.get(`/admin/producto/${target}/${props.id}`, {}, opts)

}

</script>


<template>

  <div class="flex justify-center gap-1">
            <slot></slot>
            <div class="tooltip" data-tip="Ver">
              <button class="btn" @click="goTo('view')">
                <font-awesome-icon icon="fa-solid fa-eye"></font-awesome-icon>
              </button>
            </div>
            <div class="tooltip" data-tip="Editar">
              <button class="btn bnt-info" @click="goTo('edit')">
                <font-awesome-icon
                  icon="fa-solid fa-pencil"
                ></font-awesome-icon>
              </button>
            </div>
            <div class="tooltip" data-tip="Borrar">
              <button class="btn bnt-info">
                <font-awesome-icon icon="fa-solid fa-trash"></font-awesome-icon>
              </button>
            </div>
          </div>


</template>