<script setup lang="ts">
import { atlasUseCartStore } from '@/Pages/cart/store/cart.store';

const { addProduct } = atlasUseCartStore()

</script>


<template>
    <div
          class="card bg-base-300 w-full shadow-sm flex justify-center"
          v-for="i in [1, 1, 1, 1]"
        >
          <figure>
            <img
              src="https://img.daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.webp"
              alt="Shoes"
            />
          </figure>
          <div class="card-body">
            
            <button  class="card-title text-primary hover:underline">
              <Link href="/store/product?id=12">
              Card Title
              </Link>
            </button>
            <p>
              A card component has a figure, a body part, and inside body there
              are title and actions parts
            </p>
            <div class="card-actions justify-end">
              <button class="btn btn-primary" @click="addProduct({})">Buy Now</button>
            </div>
          </div>
        </div>
</template>