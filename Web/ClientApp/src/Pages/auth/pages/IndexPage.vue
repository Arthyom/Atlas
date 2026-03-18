<script setup lang="ts">
import { useAtlasComposableCustomFormActions } from "@/Models/Composables/AtlasComposableCustomFormActions";
import { useAtlasComposableFormActions } from "@/Models/Composables/AtlasComposableFormActions";
import { useAtlasComposableLoadingCallbacks } from "@/Models/Composables/AtlasComposableLoadingCallbacks";
import LayOutAuthPage from "@/Pages/layouts/auth/components/LayOutAuthPage.vue";
import { useForm } from "@inertiajs/vue3";
import { reactive, ref } from "vue";
import IAtlasMixedResponse from '../../../Models/Interfaces/IAtlasMixedResponse';
import { IDtoUsuarioResponse } from "../DTOs/IDtoUsuario";


const { opts } = useAtlasComposableLoadingCallbacks();

const eyeOpen = reactive({
  open: false,
  textType: 'password',
  iconName:'fas fa-eye'
})


const login = reactive({
  user:null,
  password:null
})

const togleIconEye = () =>{
  if(!eyeOpen.open){
    eyeOpen.iconName = 'fas fa-eye-slash';
    eyeOpen.textType = 'text'
  }
  else{
    eyeOpen.iconName = 'fas fa-eye';
    eyeOpen.textType = 'password'
  }
  eyeOpen.open = !eyeOpen.open
}


const access = () =>{
  opts.onStart({});

    const form = useForm<any>(login);

    form.post('/auth/post', {
      _method: "post",
      forceFormData: true,
      opts,
    });

  // s.submitCustomFormWithDataAndUrl  (login, '/auth')
}

// 
</script>

<template>
  <LayOutAuthPage>
    <div class="card bg-base-100 w-full shadow-lg">

      <div class="card-body items-center text-center">
        <div>
            <h2 class="card-title">Bienvenido</h2>
            <h2>Inicia Sesion</h2>
        </div>

        <div class="divider my-0"></div>


        <div class="flex flex-col gap-3 my-5 md:my-7  w-full items-center">

            <div class="join w-full">
              <div class="w-full">
                <label class="input validator join-item w-full">
                
                    <font-awesome-icon
                    class="h-[1em] opacity-50"
                    icon="fas fa-user">
                    </font-awesome-icon>
                 
                  <input  placeholder="Usuario" required v-model="login.user"/>
                </label>
              </div>
            </div>
    
             <div class="join w-full">
              <div class="w-full">
                <label class="input validator join-item w-full">
    
         
                   <font-awesome-icon
                    class="h-[1em] opacity-50"
                    icon="fas fa-key">
                    </font-awesome-icon>
    
                  <input :type="eyeOpen.textType" placeholder="Contraseña" required   v-model="login.password"/>
                </label>
              </div>
              <button class="btn btn-neutral join-item" @click="togleIconEye">
                 <font-awesome-icon
                    class="h-[1em]"
                    :icon="eyeOpen.iconName">
                    </font-awesome-icon>
              </button>
            </div>
        </div>
  
        <div class="divider my-0"></div>

        <div class="card-actions   w-full">
            <div class="w-full flex flex-row gap-2 ">
                <button class="btn flex-1 btn-success " @click="access">Entrar</button>
                <button class="btn flex-1 btn-error ">Cancelar</button>
            </div>
        </div>
      </div>
    </div>
  </LayOutAuthPage>
</template>
