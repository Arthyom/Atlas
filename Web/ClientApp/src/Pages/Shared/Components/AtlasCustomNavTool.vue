<script setup lang="ts">
import IAtlasCustomNavToolConfig from "@/Models/Interfaces/IAtlasCustomNavToolConfig";

import { Link } from "@inertiajs/vue3";

const props = defineProps<IAtlasCustomNavToolConfig>();
const linkToAdd = `/admin/${props.configs.resource}/create`;
</script>

<template>
  <div class="bg-gree-500 ">
    <div class="hidden md:flex bg-gray-200">
      <div class="navbar bg-gray-200 shadow-sm mt-2">
        <div class="navbar-start">
          <div class="dropdown">
            <div tabindex="0" role="button" class="btn btn-ghost lg:hidden">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="h-5 w-5"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M4 6h16M4 12h8m-8 6h16"
                />
              </svg>
            </div>
            <ul
              tabindex="0"
              class="menu menu-sm dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow"
            >
              <li><a>Item 1</a></li>
              <li>
                <a>Parent</a>
                <ul class="p-2">
                  <li><a>Submenu 1</a></li>
                  <li><a>Submenu 2</a></li>
                </ul>
              </li>
              <li><a>Item 3</a></li>
            </ul>
          </div>
          <a class="btn btn-ghost text-xl">{{ configs.title }}</a>
        </div>
        <div class="navbar-center hidden lg:flex"></div>
        <div class="navbar-end">
          <div class="flex  w-full">

            <slot name="buttonSloSlot"></slot>
          </div>
          <input
            type="text"
            placeholder="Search"
            class="input input-bordered w-24 md:w-auto mr-2"
          />

          <Link class="btn btn-circle btn-success avatar" :href="linkToAdd">
            <font-awesome-icon icon="fas fa-plus"></font-awesome-icon>
          </Link>
        </div>
      </div>
    </div>

    <div class="flex md:hidden border-b border-gray-300">
      <div class="navbar bg-base-300">
        <div class="navbar-start">
          <div class="dropdown">
            <div
              tabindex="0"
              role="button"
              class="btn btn-ghost lg:hidden text-2xl"
            >
              {{ configs.title }}
            </div>
            <ul
              tabindex="0"
              class="menu menu-sm dropdown-content bg-base-100 rounded-box z-1 w-52 p-2 shadow"
            >
              <li>
                <input
                  type="text"
                  placeholder="Search"
                  class="input input-bordered w-full"
                />
              </li>
              <li>
                <slot name="buttonSloSlot"></slot>
              </li>
            </ul>
          </div>
        </div>

        <div class="navbar-center hidden lg:flex"></div>
        <div class="navbar-end">
          <div class="flex flex-row">
            <div>
              <Link class="btn btn-circle btn-success avatar" :href="linkToAdd">
                <font-awesome-icon icon="fas fa-plus"></font-awesome-icon>
              </Link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
