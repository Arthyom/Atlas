<script setup lang="ts">
import { IAtlasCustomControl } from "@/Models/Interfaces/IAtlasCustomControl";

const properties = defineProps<IAtlasCustomControl>();

const emitters = defineEmits(["update:modelValue", "blur", "emit-objects"]);

const emitData = (event: any) => {
  properties.genericFunction(event);

  console.log("elementos enviados", properties.modelValue);

  const objectSelect = event.target as HTMLSelectElement;

  if (properties.returnObjectValue) {
    const itemText = objectSelect.selectedOptions[0].innerText;
    const selectData = {
      value: objectSelect.value,
      text: itemText,
      keyLabel: properties.keyLabel,
    };
    emitters("emit-objects", selectData);
  }

  emitters("update:modelValue", objectSelect.value);
};
</script>

<template>
  <div class="flex flex-col" :class="customClassContainer">
    <label class="font-bold text-lg" :class="customClassLable"
      >{{ label }}<span class="text-error" v-if="isRequired">*</span></label
    >

    <!-- <select class="select w-full"
      :class="{'input-error':error}"
            :value="modelValue"
            @blur="$emit('blur')"

            @change="
          $emit('update:modelValue', ($event.target as HTMLInputElement).value)
        "

    > -->
     
    <template v-if="properties.hasKey">
      <pre>{{ properties }}</pre>
      ssss{{ properties.keyLabel }}
      <select
        class="select w-full"
        id="estadoId"
        :class="{ 'input-error': error }"
        :value="modelValue"
        @blur="emitters('blur')"
        @change="emitData($event)"
      >
        <option disabled selected :key="''">Seleccione</option>
        <option
          v-for="item in additionalData"
          :value="item.key"
          :key="properties.hasKey"
        >
          {{ item.value }}
        </option>
      </select>
    </template>
    <template v-else>
      <select
        class="select w-full"
        :class="{ 'input-error': error }"
        :value="modelValue"
        @blur="emitters('blur')"
        @change="emitData($event)"
      >
        <option disabled selected :key="''">Seleccione</option>
        <option
          v-for="item in additionalData"
          :value="item.key"
          :key="properties.hasKey"
        >
          {{ item.value }}
        </option>
      </select>
    </template>

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
    <p class="pt-1 text-muted text-error" :class="customClassError">
      {{ error }}
    </p>
  </div>
</template>
