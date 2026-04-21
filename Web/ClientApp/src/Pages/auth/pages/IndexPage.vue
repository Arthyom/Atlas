<script setup lang="ts">
import { useAtlasComposableCustomFormActions } from "@/Models/Composables/AtlasComposableCustomFormActions";
import { useAtlasComposableFormActions } from "@/Models/Composables/AtlasComposableFormActions";
import { useAtlasComposableLoadingCallbacks } from "@/Models/Composables/AtlasComposableLoadingCallbacks";
import LayOutAuthPage from "@/Pages/layouts/auth/components/LayOutAuthPage.vue";
import { router, useForm } from "@inertiajs/vue3";
import { computed, reactive, ref } from "vue";
import IAtlasMixedResponse from "../../../Models/Interfaces/IAtlasMixedResponse";
import { IDtoUsuarioResponse } from "../DTOs/IDtoUsuario";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";

const { opts } = useAtlasComposableLoadingCallbacks();

const eyeOpen = reactive({
  open: false,
  textType: "password",
  iconName: "fas fa-eye",
});

const login = reactive<{ user: string | null; password: string | null }>({
  user: null,
  password: null,
});

const togleIconEye = () => {
  if (!eyeOpen.open) {
    eyeOpen.iconName = "fas fa-eye-slash";
    eyeOpen.textType = "text";
  } else {
    eyeOpen.iconName = "fas fa-eye";
    eyeOpen.textType = "password";
  }
  eyeOpen.open = !eyeOpen.open;
};

const isFormValid = computed(() => login.password && login.user);

const isError = ref(false);

const access = async () => {
  opts.onStart({});

  const form = useForm<any>(login);

  const c = useAtlasComposableAjaxActions("");

  const { password, user } = form;

  debugger;

  opts.onStart({});

  const response = await c.sendRequest(
    { password, user },
    "post",
    "/auth/post",
  );
  if (!response) {
    isError.value = true;
    login.password = "";
    login.user = "";
  }
  
  if(response?.status === 200){
    router.get('/admin/producto/index')
  }

  opts.onFinish({});

  setTimeout(() => {
    isError.value = false;
  }, 3000);

  // s.submitCustomFormWithDataAndUrl  (login, '/auth')
};

//
</script>

<template>
  <LayOutAuthPage>
    <div v-if="isError">
      <div role="alert" class="alert alert-error mb-10">
        <font-awesome-icon
                  class="h-[1em] opacity-50"
                  icon="fas fa-close"
                >
                </font-awesome-icon>
        <span>Usuario o Contraseña incorrectos</span>
      </div>
    </div>

    <div class="card bg-base-100 w-full shadow-lg">
      <div class="card-body items-center text-center">
        <div>
          <h2 class="card-title">Bienvenido</h2>
          <h2>Inicia Sesion</h2>
        </div>

        <div class="divider my-0"></div>

        <div class="flex flex-col gap-3 my-5 md:my-7 w-full items-center">
          <div class="join w-full">
            <div class="w-full">
              <label class="input validator join-item w-full">
                <font-awesome-icon
                  class="h-[1em] opacity-50"
                  icon="fas fa-user"
                >
                </font-awesome-icon>

                <input placeholder="Usuario" required v-model="login.user" />
              </label>
            </div>
          </div>

          <div class="join w-full">
            <div class="w-full">
              <label class="input validator join-item w-full">
                <font-awesome-icon class="h-[1em] opacity-50" icon="fas fa-key">
                </font-awesome-icon>

                <input
                  :type="eyeOpen.textType"
                  placeholder="Contraseña"
                  required
                  v-model="login.password"
                />
              </label>
            </div>
            <button class="btn btn-neutral join-item" @click="togleIconEye">
              <font-awesome-icon class="h-[1em]" :icon="eyeOpen.iconName">
              </font-awesome-icon>
            </button>
          </div>
        </div>

        <div class="divider my-0"></div>

        <div class="card-actions w-full">
          <div class="w-full flex flex-row gap-2">
            <button
              class="btn flex-1 btn-success"
              @click="access"
              :disabled="!isFormValid"
            >
              Entrar
            </button>
            <button class="btn flex-1 btn-error">Cancelar</button>
          </div>
        </div>
      </div>
    </div>
  </LayOutAuthPage>
</template>
