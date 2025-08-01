import { IAtlasCustomControl } from
'../../../Models/Interfaces/IAtlasCustomControl';
<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { IAtlasCustomControl } from "@/Models/Interfaces/IAtlasCustomControl";
import { ref } from "vue";

interface IAtlasCustomInputFile extends IAtlasCustomControl {
  multiple?: boolean;
  files: string[] 
}

const {getFileFrom} = useAtlasComposableUseFilesFetcher()
const props = defineProps<IAtlasCustomInputFile>();
const emits = defineEmits(['update:modelValue'])

const filesFromUlr = ref<any[]>([]);
const filesFromImg = ref<File[]>([]);

const emitImages = (event : Event) =>{

  
  const filesFromList = (event.target as HTMLInputElement).files
  
  if(!filesFromList) return


  
  for (let i = 0; i < filesFromList.length; i++) {
    const image = filesFromList[i];
    const file = filesFromList[i];
    
    filesFromUlr.value.push( URL.createObjectURL(image) )
    filesFromImg.value.push(file)
    
  }

  emits('update:modelValue', filesFromImg.value)
}
</script>

<template>
  
  <div class="flex flex-col col-span-4  h-105">
    <label class="font-bold text-lg"
            >{{ label
            }}<span class="text-error" v-if="isRequired">*</span></label
          >

    <div class="flex-1 carousel w-full h-full">
      <template v-for="(imageUrl,i) in filesFromUlr" :key="i">

        <div :id="`slide${i}`" class="carousel-item relative w-full">
        <img
          :src="imageUrl"
          class="w-full"
        />

        <div v-if="filesFromUlr.length > 1"
          class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between"
        >
        <template v-if="i==0">
          <a :href="`#slide${filesFromUlr.length-1}`" class="btn btn-circle">❮</a>
        </template>
        <template v-else>
          <a :href="`#slide${i-1}`" class="btn btn-circle">❮</a>
        </template>

        <template v-if="i==filesFromUlr.length">
          <a :href="`#slide0`" class="btn btn-circle">❮</a>
        </template>
        <template v-else>
          <a :href="`#slide${i+1}`" class="btn btn-circle">❯</a>
        </template>

        </div>

      </div>


      </template>

     
      <template v-for="(imageUrl,i) in files" :key="i">

        <div :id="`slide${i}`" class="carousel-item relative w-full">
        <img
          :src="getFileFrom('producto','admin', imageUrl )"
          class="w-full"
        />

        <div v-if="files.length > 1"
          class="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between"
        >
        <template v-if="i==0">
          <a :href="`#slide${files.length-1}`" class="btn btn-circle">❮</a>
        </template>
        <template v-else>
          <a :href="`#slide${i-1}`" class="btn btn-circle">❮</a>
        </template>

        <template v-if="i==files.length">
          <a :href="`#slide0`" class="btn btn-circle">❮</a>
        </template>
        <template v-else>
          <a :href="`#slide${i+1}`" class="btn btn-circle">❯</a>
        </template>

        </div>

      </div>


      </template>

      <template v-if="filesFromUlr.length ===0 || !files">
        <div class="alert alert-info w-full">
          No Images loaded
        </div>
      </template>

       
      
      
     
    </div>

    <div class="flex flex-col">
      <template v-if="multiple">
        <fieldset class="fieldset">
          <input
            name="imagenes"
            multiple
            class=" file-input w-full"
            :class="{ 'file-input-error': error }"
            type="file"
            @change="emitImages"
          />
          <p class="pt-1 text-muted text-error">{{ error }}</p>
        </fieldset>
      </template>
      <template v-else>
        <h1>golaaa</h1>
      </template>
    </div>
  </div>
</template>
