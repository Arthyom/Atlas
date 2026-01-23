<script setup lang="ts">
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";
import { AtlasEnumInputType } from "@/Models/Enums/AtlasEnumInputType";
import { IAtlasCustomFormConfig } from "@/Models/Interfaces/IAtlasCustomFormConfig";
import AtlasCustomTemplateForm from "@/Pages/Shared/Components/AtlasCustomTemplateForm.vue";
import {
  onBeforeMount,
  onMounted,
  onUpdated,
  reactive,
  ref,
  useTemplateRef,
  watch,
  watchEffect,
} from "vue";
import * as yup from "yup";
import {
  IDtoExtApiCountry,
  IDtoExtApiCountryResponse,
  IDtoExtApiState,
} from "../../../Models/DTOs/APIs/CountryInfo/Country.interface";
// import { IDtoApiState } from "@/Models/DTOs/APIs/Ecart/IDtoEcartState";
import { AtlasHelperProducto } from "@/Models/Helpers/AtlasHelper";
import { useAtlasComposableMapKeyValue } from "@/Models/Composables/AtlasComposableMapKeyValue";
import { IAtlasKeyValue } from "@/Models/Interfaces/IAtlasKeyValue";
import { AtlasDataCountries } from "@/Models/AtlasDataCountries.data";


const fetcher = useAtlasComposableAjaxActions<IDtoExtApiCountryResponse>(
  "",
  "",
  "https://countriesnow.space/api/v0.1/countries/states"
);
const mapper = useAtlasComposableMapKeyValue();

const countries = mapper.mapToKeyValueWithId(
  AtlasDataCountries,
  "name",
  "iso2"
);
const countriesAsObject = mapper.mapToObjectFromArray(
  AtlasDataCountries,
  "iso2",
  "states"
) as any;

const configs = reactive<IAtlasCustomFormConfig>({
  title: "",
  resource: "Dir",
  sectionTitle: "",
  customClassTitle: "text-center text-2lg mt-0",
  customClassContainer: "sm:grid-cols-6",
  customClassDivider:'hidden',
  formSchema: [
    // {
    //     schema: {pais: yup.string().required().label('Pais')},
    //     config: {

    //         // showControl:true,

    //         typeInput: AtlasEnumInputType.select
    //         ,showControl: true
    //         ,customClassLable: 'text-sm md:text-lg '
    //         ,customClassError: 'hidden'
    //         ,customClassContainer: 'sm:col-span-3'
    //         ,returnObjectValue:true
    //         ,keyLabel: 'paisIdObjectValue'
    //         ,additionalData: countries
    //         ,genericFunction: (e:any)=> {
    //             const objectSelect = (e.target as HTMLSelectElement)
    //             stateCode.value = objectSelect.selectedOptions[0].value
    //             console.log('value', stateCode.value)
    //             console.log('essss', countriesAsObject)
    //         }
    //     }
    // },

    // {
    //     schema: {estado: yup.string().required().label('Estado')},
    //     config: {
    //         hasKey:'ssss',
    //         showControl:true,
    //         typeInput: AtlasEnumInputType.select
    //         ,customClassLable: 'text-sm md:text-lg '
    //         ,customClassError: 'hidden'
    //         ,customClassContainer: 'sm:col-span-3'
    //         // ,additionalData:
    //         ,genericFunction: (e:any)=>{
    //             console.log('triggering event', e)
    //         }
    //     }
    // },

    {
      schema: { ciudad: yup.string().required().label("Ciudad o Municipio") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-3",
      },
    },

    // {
    //     schema: {municipioId: yup.string().required().label('Ciudad o Municipio')},
    //     config: {
    //         customClassLable: 'text-sm md:text-lg '
    //         ,customClassError: 'hidden'
    //         ,customClassContainer: 'sm:col-span-3'
    //         ,additionalData:[
    //             {value:'moroleon', key:1}
    //         ]

    //     }
    // },

    // {
    //     schema: {coloniaId: yup.string().required().label('Colonia')},
    //     config: {
    //         customClassLable: 'text-sm md:text-lg '
    //         ,customClassError: 'hidden'
    //         ,customClassContainer: 'sm:col-span-3'
    //         ,additionalData:[
    //             {value:'colonia el cuyo', key:1}
    //         ]
    //     }
    // },

    /// direccion primaria is being hidden in favor of street name
    // {
    //   schema: {
    //     direccionPrimaria: yup.string().required().label("Direccion Primaria"),
    //   },
    //   config: {
    //     customClassLable: "text-sm md:text-lg ",
    //     customClassError: "hidden",
    //     customClassContainer: "sm:col-span-3",
    //   },
    // },

    {
      schema: {
        calle: yup.string().required().label("Calle"),
      },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-3",
      },
    },

    {
      schema: {
        numeroExterior: yup.string().required().label("# Ext."),
      },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-3",
      },
    },

    {
      schema: {
        numeroInterior: yup.string().required().label("# Int."),
      },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-3",
      },
    },

    {
      schema: {
        colonia: yup.string().required().label("# Ext"),
      },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-3",
      },
    },

    {
      schema: {
        colonia: yup.string().required().label("Colonia"),
      },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-3",
      },
    },

    /// was being hidden in favor of only 1 direcction
    // {
    //   schema: {
    //     direccionSecundaria: yup.string().label("Direccion Secundaria"),
    //   },
    //   config: {
    //     customClassLable: "text-sm md:text-lg ",
    //     customClassError: "hidden",
    //     customClassContainer: "sm:col-span-3",
    //   },
    // },

    {
      schema: { cp: yup.number().required().label("CP") },
      config: {
        customClassLable: "text-sm md:text-lg ",
        customClassError: "hidden",
        customClassContainer: "sm:col-span-3",
      },
    },
    {
      schema: {  }
    }
    // {
    //     schema: {exterior: yup.number().required().label('#Ext.')}
    //     ,config: {
    //         customClassLable: 'text-sm md:text-lg '
    //         ,customClassError: 'hidden'
    //         ,customClassContainer:'sm:col-span-2'
    //     }
    // },
    // {
    //     schema: {interior: yup.number().label('#Int.')}
    //     ,config:{
    //         customClassLable: 'text-sm md:text-lg'
    //         ,customClassError: 'hidden'
    //         ,customClassContainer:'sm:col-span-2'
    //     }
    // },
    // {
    //     schema: {entreCalles: yup.string().label('Entre Calles')}
    //     ,config: {
    //         customClassLable: 'text-sm md:text-lg '
    //         ,customClassError: 'hidden'
    //         ,customClassContainer: 'sm:col-span-6'
    //     }
    // },
    ,{
        schema: {referencias: yup.string().required().label('Referencias')}
        ,config: {
            typeInput: AtlasEnumInputType.area,
            customClassLable: 'text-sm md:text-lg '
            ,customClassError: 'hidden'
            ,customClassContainer: 'sm:col-span-6'
        }
    },
  ],
});

const states = ref<IAtlasKeyValue[]>()

const selectCountry = (e:any)=>{

    const countryCode = (e.target as HTMLSelectElement ).value

    const sts = mapper.mapToKeyValueWithId(
        countriesAsObject[countryCode]?.states || [],
        "name",
        "state_code"
    );

    paisEstado.value.paisName = countries.filter( x => x.key === countryCode)[0].value
    states.value = sts
}

const emiters = defineEmits(['emit-address'])

const emitFormOk = (event:any) => {
    const toEmit = { data: { ...event.data, ...paisEstado.value } }
    emiters("emit-address", toEmit)

    console.log('form ok', toEmit)
}
const paisEstado = ref<{paisCode:string, estado:string, paisName: string}>({ paisName: '', paisCode:'', estado:''})
</script>

<template>
  <div class="p-4">
    <template v-if="fetcher.getState">
      <div class="grid grid-cols-2 gap-4">
      
        <fieldset class="fieldset">
          <legend class="fieldset-legend text-sm md:text-lg ">Pais <spam class="text-red-500">*</spam> </legend>
          <select v-model="paisEstado.paisCode" class="select validator w-full" required @change="selectCountry($event)">
            <option  selected>Seleccione</option>
            <option v-for="country in countries" :value="country.key">{{ country.value }}</option>
          </select>
          <span class="validator-hint">Optional</span>
        </fieldset>

        <fieldset class="fieldset">
          <legend class="fieldset-legend text-sm md:text-lg">Estado <spam class="text-red-500">*</spam>  </legend>
          <select v-model="paisEstado.estado" class="select validator w-full" required>
            <option selected >Seleccione</option>
            <option v-for="state in  states" :value="state.key">{{ state.value }}</option>
          </select>
          <span class="validator-hint">Optional</span>
        </fieldset>

     
      </div>
      <AtlasCustomTemplateForm
        @form-ok="emitFormOk($event)"
        :configs="configs"
      ></AtlasCustomTemplateForm>
    </template>
  </div>
</template>
