<script setup lang="ts">
import { useAtlasComposableUserStore } from "@/Models/Composables/AtlasComposableUserStore";
import { Link } from "@inertiajs/vue3";

const {userInfo} = useAtlasComposableUserStore()
</script>

<template>
  <div class="navbar bg-base-100 shadow-sm">
    <div class="navbar-start">
      <label for="my-drawer-4">

          <div class="dropdown dropdown-end">
            <div
              tabindex="0"
              role="button"
              class="btn btn-ghost btn-circle avatar"
            >
              <div class="w-10 rounded-full">
                
                <img
                  alt="Tailwind CSS Navbar component"
                  src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp"
                />
              </div>
            </div>
            
          </div>
        </label>
    </div>
    <div class="navbar-center hidden md:flex">
      <!-- <ul class="menu menu-horizontal px-1">
        <li><Link href="/admin/producto/index">Productos</Link></li>
        <li><Link href="/admin/categoria/index">Categorias</Link></li>
        <li><Link href="/admin/productos/index">Vender</Link></li>
      </ul> -->
    </div>

    <div class="navbar-end">
      <div class="flex flex-row gap-5 mr-5"></div>

      <div class="flex flex-row">
          <h1 class="flex items-center font-extrabold text-xl">{{ userInfo?.nombre }} </h1> | <h1 class="text-xl"> {{ userInfo?.rol }}</h1>
      </div>


       
    </div>
  </div>
</template>
