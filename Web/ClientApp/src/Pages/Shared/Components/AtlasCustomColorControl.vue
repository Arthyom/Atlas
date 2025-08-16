<script setup lang="ts">
import { IAtlasCustomControl } from "@/Models/Interfaces/IAtlasCustomControl";

defineProps<IAtlasCustomControl>();
</script>

<template>
  <div class="flex flex-col">
    <label class="font-bold text-lg"
      >{{ label }} <span class="text-error" v-if="isRequired">*</span>
    </label>
    <label class="input w-full" :class="{ 'input-error': error }">
      <template v-if="icon">
        <font-awesome-icon :icon="icon"></font-awesome-icon>
      </template>
      <input
        :placeholder="placeHolder"
        type="color"
        :value="modelValue"
        @input="
          $emit('update:modelValue', ($event.target as HTMLInputElement).value)
        "
        @blur="$emit('blur')"
      />
    </label>
    <p class="pt-1 text-muted text-error">{{ error }}</p>
  </div>
</template>
