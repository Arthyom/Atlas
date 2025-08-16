<script setup lang="ts">
import { atlasCompsUseCustomControlState } from '@/Models/Composables/AtlasComposableCustomControl';
import { IAtlasCustomFormWrapper } from '@/Models/Interfaces/IAtlasCustomFormWrapper';
import { useForm } from "vee-validate";
import { AtlasEnumInputType } from '@/Models/Enums/AtlasEnumInputType';
import AtlasCustomInputControl from './AtlasCustomInputControl.vue';
import * as yup from 'yup';
import { IAtlasCustomControl } from '@/Models/Interfaces/IAtlasCustomControl';
import AtlasCustomSelect from './AtlasCustomSelect.vue';
import AtlasCustomTextArea from './AtlasCustomTextArea.vue';
import { onUpdated, h } from 'vue';
import AtlasCustomInputFileControl from './AtlasCustomInputFileControl.vue';
import AtlasCustomColorControl from './AtlasCustomColorControl.vue';

const props = defineProps<IAtlasCustomFormWrapper>()
const emit = defineEmits(['formOk'])

const fields: any[] = [];
const validationSchema: any = {}
const properties: IAtlasCustomControl[]  = []
const atlasEnumType = AtlasEnumInputType

const {conf} = atlasCompsUseCustomControlState()



props.configs.formSchema.forEach( i => {
  for (const key in i.schema) {
    validationSchema[key] = i.schema[key] 
  }
  properties.push(i.config ?? {})
});


const { values, defineField, errors, meta } = useForm({
  validationSchema,
  initialValues: props.configs.initialValues
});

let i = 0
for (const key in validationSchema) {

  const controlConf = validationSchema[key]


  const controlConfTemplate : IAtlasCustomControl = {
    label: controlConf.spec.label ? controlConf.spec.label: key,
    isRequired: !controlConf.spec.optional ,
    typeInput : properties[i].typeInput ?  properties[i].typeInput : controlConf.type,
    additionalData: properties[i].additionalData,
    icon: properties[i].icon,
    placeHolder: properties[i].placeHolder,

  }


    let field = defineField(key, {
        props: (state: any) =>
        conf(state,controlConfTemplate),
    });
  
    i++;
  
  fields.push(field);
}


onUpdated( () =>{
  if(!!props.configs.initialValues && !meta.value.touched){
    emit('formOk', {data:values, isValid: true})
    return;
  }

  if(!!props.configs.initialValues && meta.value.touched){
    emit('formOk', {data:values, isValid: meta.value.valid})
    return;
  }

  if(meta.value.valid)
    emit('formOk', {data:values, isValid: meta.value.valid})
  
  // emit('formOk', {data: null, isValid: meta.value.valid});
})

</script>

<template>
<div class=" sm:hidden" >
    <div class="bg-base-300 border-base-300 collapse  collapse-arrow border my-4">
        <input type="checkbox" class="peer" />

        <div
          class="collapse-title text-xl font-bold"
        >
          {{props.configs.sectionTitle}}
        </div>
        <div
          class="collapse-content bg-base-100  "
        >
          <template v-for="(field, x) in fields">

          <template v-if="properties[x].typeInput === atlasEnumType.area">
            <AtlasCustomTextArea v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.check">

          </template>

              <template v-else-if="properties[x].typeInput === atlasEnumType.file">
            <AtlasCustomInputFileControl v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
                
          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.files">
            <AtlasCustomInputFileControl :multiple="true" v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>


          <template v-else-if="properties[x].typeInput === atlasEnumType.radio">

          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.select">
            <AtlasCustomSelect v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

          <template v-else>
            <AtlasCustomInputControl v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

        </template> 

        <div class="">
          <slot></slot>
        </div>

        <div>
          <slot name ='buttons'></slot>
        </div>
        </div>
    
      </div>
</div>


<div class="hidden sm:block bg-base-100  w-full h-full rounded-md" >
    <div class=" ">
        <h1 class="mt-4 mb-1 text-3xl font-bold  text-slate-600">{{ props.configs.sectionTitle }}</h1> 
        <hr class=""/>
      </div>

       <div class="grid sm:grid-cols-3 lg:grid-cols-4 gap-4 mt-4">
           <template v-for="(field, x) in fields">

          <template v-if="properties[x].typeInput === atlasEnumType.area">
            <AtlasCustomTextArea v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.check">

          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.file">
            <AtlasCustomInputFileControl v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.files">
            <AtlasCustomInputFileControl :files="configs.initialValues" :multiple="true" v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.radio">

          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.select">
            <AtlasCustomSelect v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

          <template v-else-if="properties[x].typeInput === atlasEnumType.color">
            <AtlasCustomColorControl v-model="field[0].value" v-bind="field[1].value" :props="properties"></AtlasCustomColorControl>
          </template>

          <template v-else>
            <AtlasCustomInputControl v-model="field[0].value" v-bind="field[1].value" :props="properties"/>
          </template>

            </template>
            
          </div>
          <div class="">
            <slot></slot>
          </div>

          <div>
            <slot name ='buttons'></slot>
          </div>
</div>

    
</template>