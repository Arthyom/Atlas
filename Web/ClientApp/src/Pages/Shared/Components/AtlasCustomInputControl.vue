<script setup lang="ts">
import { IAtlasCustomControl } from '@/Models/Interfaces/IAtlasCustomControl';


defineProps<IAtlasCustomControl>();


</script>


<template>
      <div class="flex flex-col" :class="customClassContainer">
    <label class="font-bold text-lg" :class="customClassLable">{{ label }} <span class="text-error" v-if="isRequired">*</span> </label>
    <label class="input w-full" :class="{'input-error': error}">
      <template v-if="icon">
        <font-awesome-icon :icon="icon"></font-awesome-icon>
      </template>
      <input
        
        :placeholder="placeHolder"
        :type="typeInput"
        :value="modelValue"
        @input="
          $emit('update:modelValue', ($event.target as HTMLInputElement).value)
        "
        @blur="$emit('blur')"
        
      />
    </label>
    <p class="pt-1 text-muted text-error" :class="customClassError">{{ error }}</p>
  </div>
</template>