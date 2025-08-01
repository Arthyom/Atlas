<script setup lang="ts">
import { IAtlasCustomControl } from "@/Models/Interfaces/IAtlasCustomControl";

defineProps<IAtlasCustomControl>();
</script>

<template>
  <div class="lg:col-span-4 sm:col-span-3">
    
    <div class="flex flex-col ">
      <label class="font-bold text-lg "
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
      <p class="pt-1 text-muted text-error">{{ error }}</p>
    </div>
  </div>
</template>
