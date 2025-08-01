<script setup lang="ts">
import { IAtlasCustomControl } from '@/Models/Interfaces/IAtlasCustomControl';


defineProps<IAtlasCustomControl>();


</script>


<template>
    <div class="flex flex-col ">
    <label class="font-bold text-lg" >{{ label }}<span class="text-error" v-if="isRequired">*</span></label>

    <select class="select w-full"
      :class="{'input-error':error}"
            :value="modelValue"
            @blur="$emit('blur')"
            @change="
          $emit('update:modelValue', ($event.target as HTMLInputElement).value)
        "

    >
      <option disabled selected>Seleccione</option>
      <option v-for="item in additionalData" :value="item.key">{{ item.value }}</option>
     
    </select>

    <!-- <label class="input">
      <font-awesome-icon :icon="props.icon"></font-awesome-icon>
      <input
        :placeholder="props.placeHolder"
        type="text"
        :value="props.modelValue"
        @input="
          $emit('update:modelValue', ($event.target as HTMLInputElement).value)
        "
        @blur="$emit('blur')"
      />
    </label> -->
    <p class="pt-1 text-muted text-error">{{ error }}</p>
  </div>
</template>