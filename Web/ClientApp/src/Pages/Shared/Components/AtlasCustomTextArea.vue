<script setup lang="ts">
import { IAtlasCustomControl } from "@/Models/Interfaces/IAtlasCustomControl";

const props = defineProps<IAtlasCustomControl>();
</script>

<template>
  <div class="flex flex-col lg:col-span-4 sm:col-span-3" :class="customClassContainer">
    
      <label class="font-bold text-lg " :class="customClassLable"
        >{{ label }}<span class="text-error" v-if="isRequired">*</span></label
      >
      <textarea
        :placeholder="placeHolder"
        :value="modelValue"
        @input="
          $emit('update:modelValue', ($event.target as HTMLInputElement).value)
        "
        @blur="$emit('blur')"
        @keydown="genericFunction"
        class="input  w-full h-full"
        :class="{'input-error': error}"
        
        rows="6"
      >
      </textarea>
      <p class="pt-1 text-muted text-error" :class="customClassError">{{ error }}</p>
  </div>
</template>
