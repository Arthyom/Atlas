<script setup lang="ts">
import AtlasCustomModalControl from "@/Pages/Shared/Components/AtlasCustomModalControl.vue";
import { IDtoEnvio } from "../interfaces/IDtoEnvio";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";
import { onBeforeMount, ref } from "vue";
import { IDtoGuiaResponse } from "../interfaces/IDtoGuiaResponse";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import { saveAs } from "file-saver";

const props = defineProps<IDtoEnvio>();

const resp = ref<IAtlasMixedResponse<IDtoGuiaResponse>>();

onBeforeMount(async () => {
  try {
    const comAjax = useAtlasComposableAjaxActions(
      "guide",
      "admin",
      "/admin/guide/json/11"
    );

    resp.value = await comAjax.getUrl<IAtlasMixedResponse<IDtoGuiaResponse>>();

    saveGuide();
  } catch (error) {}
});

const saveGuide = () => {
  if (resp.value?.mainResource?.info) {
    const binaryString = atob(resp.value?.mainResource?.info);
    const len = binaryString.length;
    const bytes = new Uint8Array(len);

    for (let i = 0; i < len; i++) {
      bytes[i] = binaryString.charCodeAt(i);
    }

    const blob = new Blob([bytes], { type: "application/pdf"  });

    window.open( URL.createObjectURL(blob), '_blank')

    // const url = URL.createObjectURL(blob);

    // // Create a temporary anchor element
    // const a = document.createElement("a");
    // a.href = url;
    // a.target = "_blank";
    // // a.download = "est-donload.pdf";

    // // Append to the document, trigger the click, and clean up
    // document.body.appendChild(a);
    // a.click();
    // document.body.removeChild(a);
    // URL.revokeObjectURL(url); // Clean up the object URL
  }
};
</script>

<template>
  <AtlasCustomModalControl
    :is-valid-ok="true"
    @close-ok="$emit('close-form', false)"
    @close-modal="$emit('close-form', false)"
  >
    <template #title>
      <h1 class="text-xl">Guia Generada</h1>
    </template>


  </AtlasCustomModalControl>
</template>
