<script setup lang="ts">
import { Head } from "@inertiajs/vue3";
import { Person } from "@/Person";
import { Message } from "@/Message";
import StoreFrontLayOutPage from "./layouts/store-front/Pages/StoreFrontLayOutPage.vue";

interface Props {
  user: Person;
  message: Message;
}

defineProps<Props>();
</script>

<template>
  <StoreFrontLayOutPage>
    <div class="flex flex-col  ">
      
  
      <div class="grid grid-cols-1 md:grid-cols-4 gap-5">
        <div
          class="card bg-base-300 w-full shadow-sm  flex justify-center"
          v-for="i in [1, 1, 1, 1]"
        >
          <figure>
            <img
              src="https://img.daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.webp"
              alt="Shoes"
            />
          </figure>
          <div class="card-body">
            <h2 class="card-title text-primary hover:underline">Card Title</h2>
            <p>
              A card component has a figure, a body part, and inside body there
              are title and actions parts
            </p>
            <div class="card-actions justify-end">
              <button class="btn btn-primary">Buy Now</button>
            </div>
          </div>
      </div>
      </div>
    </div>
  </StoreFrontLayOutPage>
</template>
