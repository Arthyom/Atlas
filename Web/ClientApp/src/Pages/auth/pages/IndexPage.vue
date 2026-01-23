<script setup lang="ts">
import LayOutAuthPage from "@/Pages/layouts/auth/components/LayOutAuthPage.vue";
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
                 
                  <input  placeholder="Usuario" required />
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
    
                  <input type="password" placeholder="Contraseña" required />
                </label>
              </div>
              <button class="btn btn-neutral join-item">
                 <font-awesome-icon
                    class="h-[1em]"
                    icon="fas fa-eye">
                    </font-awesome-icon>
              </button>
            </div>
        </div>
  
        <div class="divider my-0"></div>

        <div class="card-actions   w-full">
            <div class="w-full flex flex-row gap-2 ">
                <button class="btn flex-1 btn-success ">Entrar</button>
                <button class="btn flex-1 btn-error ">Cancelar</button>
            </div>
        </div>
      </div>
    </div>
  </LayOutAuthPage>
</template>
