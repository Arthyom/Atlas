<script setup lang="ts">
import { IAtlasCustomControl } from '@/Models/Interfaces/IAtlasCustomControl';


const propss = defineProps<IAtlasCustomControl>();

const ol = (ol:any) =>{
  if(!!ol)
  return `/${ol}`

  return '/'
}
</script>


<template>
  
      <div class="flex flex-col" :class="customClassContainer">
    <label class="font-bold text-lg" :class="customClassLable">{{ label }} <span class="text-error" v-if="isRequired">*</span> </label>
    <label class="input w-full" :class="{'input-error': error}">
      <template v-if="icon">
        <font-awesome-icon :icon="icon"></font-awesome-icon>
      </template>

      <template v-if="propss.formatFunction">
        <input
          :maxlength="max"
          :minlength="min"
          :placeholder="placeHolder"
          :type="typeInput"
          :value="propss.formatFunction(modelValue)"
          @input="
            $emit('update:modelValue', ($event.target as HTMLInputElement).value)
          "
          @blur="$emit('blur')"
        />
      </template>
      <template v-else>
        <input
          :maxlength="max"
          :minlength="min"
          :placeholder="placeHolder"
          :type="typeInput"
          :value="modelValue"
          @input="
            $emit('update:modelValue', ($event.target as HTMLInputElement).value)
          "
          @blur="$emit('blur')"
        />
      </template>
    </label>
    <p class="pt-1 text-muted text-error" :class="customClassError">{{ error }}</p>
  </div>
</template>