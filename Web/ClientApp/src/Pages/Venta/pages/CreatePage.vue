<script setup lang="ts">
import {  IAtlasDtoContainer, IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import { onMounted, reactive, ref, useTemplateRef } from "vue";
import { StreamBarcodeReader } from "vue-barcode-reader";
import { useAtlasComposableUseFilesFetcher } from '../../../Models/Composables/AtlasComposableFilesFetcher';
import {Swiper } from "swiper";
import type{ SwiperContainer } from "swiper/element";
import { AtlasComposableCustomSwipper } from "@/Models/Composables/AtlasComposableCustomSwipper";
import { useVentaComposable } from "../Composbles/VentaComposable";
import { useAtlasComposableAjaxActions } from "@/Models/Composables/AtlasComposableAjaxActions";

const {getById} = useAtlasComposableAjaxActions('producto')
const {productos, total, reduceAmount, increaseAmount, toggleProduct, addNewProduct, cantidad} = useVentaComposable(
//     [
//   {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   },
//    {cantidad:2, categoria:'ss',descripcion:'ssss', id:2, nombre: 'ssd', precioMayoreo: 3,
//     precioUnitario:3,selected: false
//   }
// ]
[]
)
const {getFirstFileForProducto} = useAtlasComposableUseFilesFetcher()

const {swipeNext, swipePrev, step} = AtlasComposableCustomSwipper('swipper')

const onDecode = async (e:string) => {
  let id: number =  +e.substring(0,11)
  const r = await getById(id)
  if(!!r){
    const beepS = new Audio("/beep.mp3");
    addNewProduct(r)
    
    beepS.play();
  }
  console.log("was decoded",e);
};

const onLoaded = (e:any) => {
  console.log("was loaded",e);

};


const scanning = ref(false);

</script>

<template>
  <AdminLayout>
    <div class="bg-gray200  w-full">
      <ul
        class="sticky top-16 z-21 steps steps-horizontal w-full pt-3 bg-white"
      >
        <li class="step" :class="{'step-info': step ==1 || step >1}">Escanear</li>
        <li class="step" :class="{'step-info': step >=2}">Revizar</li>
        <li class="step" :class="{'step-info': step >=3}">Pagar</li>
      </ul>

      <div class="">
        <swiper-container
          ref="swipper"
          class="w-full"
          slides-per-view="1"
          speed="500"
          css-mode="true"
        >
          <swiper-slide class="w-full bg-white">
            
              <div class="flex flex-col ">
                <div class="w-full">
                  <div v-if="scanning">
                    <StreamBarcodeReader
                      class="w-full"
                      @decode="onDecode"
                      @loaded="onLoaded"
                    ></StreamBarcodeReader>
                  </div>
                  <div v-else class="bg-black w-full h-[300px]"></div>
                </div>

                <div class="flex flex-col">
                  <div class="grid grid-cols-3 gap-2 m-2">
                    <button
                      class="btn btn-info w-full"
                      @click="scanning = true"
                    >
                      Escanaer
                    </button>
                    <button class="btn btn-error" @click="scanning = false">
                      Detener
                    </button>

                    <button class="btn btn-danger" @click="swipeNext">
                      Listo
                    </button>
                  </div>
                </div>

                <div class="bg-gray-300 w-full">
                  <li class="text-lg opacity-60 text-center tracking-wide">
                    producto escaneados
                  </li>
                </div>

                <div class="h-90 md:h-96 overflow-y-scroll  pt-1 pb-1 h-sceen">
                  <ul class="list bg-base-100 mt-1 m-2">
                    <div class="grid grid-cols-2">
                      <template v-if="productos.length">
                        <li
                        v-for="producto in productos"
                        class="flex shadow-lg border-1 border-base-300 rounded-md "
                      >
                        <div
                          class="flex flex-col items-center justify-center p-2 pt-1 pr-0 pb-1"
                        >
                          <div class="relative w-full ">

                              <div class="absolute  z-10">
                                <button
                                  class="btn btn-sm md:btn-sm lg:btn-md btn-base-100 btn-circle items-center"
                                >
                                  {{ producto.cantidad }}
                                </button>
                              </div>

                            <div class="avatar-group w-full">
                              <div class="avatar">
                                <div class="w-15 md:w-30 lg:w-42">
                                  <img
                                  :src="getFirstFileForProducto(producto)"
                                    class=""
                                  />
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div class="flex flex-col justify-center px-2 w-full">
                          <div class="text-md font-bold">{{ producto.nombre  }}</div>

                          <div class="">
                            <button class="btn btn-xs btn-circle btn-ghost">
                              <font-awesome-icon
                                icon="fas fa-plus"
                              ></font-awesome-icon>
                            </button>
                            <button class="btn btn-xs btn-circle btn-ghost">
                              <font-awesome-icon
                                icon="fas fa-minus"
                              ></font-awesome-icon>
                            </button>

                            <button class="btn btn-xs btn-circle btn-ghost">
                              <font-awesome-icon
                                icon="fas fa-trash"
                              ></font-awesome-icon>
                            </button>
                          </div>
                        </div>
                      </li>
                      </template>
                      <template v-else >
                        no items scanned
                      </template>
                    </div>
                  </ul>
                </div>
              </div>

            </swiper-slide>

          <swiper-slide class="w-full ">

            <div class="flex flex-col  h-[calc(84.3vh)] md:h-[calc(85.4vh)] ">

              <div class="flex flex-col h-40 text-center py-5">
                <div class=" font-light text-2xl">Productos: {{ cantidad }}</div>
                <div class="font-light text-8xl">
                  {{ total }}
                </div>

                
              </div>
              <div class="grid grid-cols-2 mx-2 mb-2 gap-2">
                  
              
                    <buton @click="swipePrev" class="btn btn-md w-full">Anterior</buton>
                    <buton @click="swipeNext" class="btn btn-md w-full">Siguiente</buton>

              </div>
              <div class="flex-1 flex-wrap   text-center h-full">

                
                   
                  <div class="bg-gray-400 py-2 text-xl  tracking-wide">
                    Listado de producto 
                  </div>
                  
                  <div class="h-125 overflow-y-scroll">
                    <ul class="list bg-base-100 mt-1 m-2 h-fu">
                     <div class="grid grid-cols-2 py-2">
                       <template v-if="productos.length">
                         <li
                         v-for="producto in productos"
                         class="flex shadow-lg border-1 border-base-300 rounded-md "
                       >
                         <div
                           class="flex flex-col items-center justify-center p-2 pt-1 pr-0 pb-1"
                         >
                           <div class="relative w-full ">
 
                               <div class="absolute  z-10">
                                 <button
                                   class="btn btn-sm md:btn-sm lg:btn-md btn-base-100 btn-circle items-center"
                                 >
                                   {{ producto.cantidad }}
                                 </button>
                               </div>
 
                             <div class="avatar-group w-full">
                               <div class="avatar">
                                 <div class="w-15 md:w-30 lg:w-42">
                                   <img
                                   :src="getFirstFileForProducto(producto)"
                                     class=""
                                   />
                                 </div>
                               </div>
                             </div>
                           </div>
                         </div>
                         <div class="flex flex-col justify-center px-2 w-full">
                           <div class="text-md font-bold">{{ producto.nombre  }}</div>
 
                           <div class="" v-if="!producto.selected">
                             <button class="btn btn-xs btn-circle btn-ghost" @click="increaseAmount(producto)">
                               <font-awesome-icon
                                 icon="fas fa-plus"
                               ></font-awesome-icon>
                             </button>
                             <button class="btn btn-xs btn-circle btn-ghost" @click="reduceAmount(producto)">
                               <font-awesome-icon
                                 icon="fas fa-minus"
                               ></font-awesome-icon>
                             </button>
 
                             <button class="btn btn-xs btn-circle btn-ghost" @click="toggleProduct(producto)">
                               <font-awesome-icon
                                 icon="fas fa-trash"
                               ></font-awesome-icon>
                             </button>
                           </div>
                           <div v-else>
                             <button class="btn btn-xs btn-circle btn-ghost" @click="toggleProduct(producto)">
                               <font-awesome-icon
                                 icon="fas fa-arrow-rotate-left"
                               ></font-awesome-icon>
                             </button>
                           </div>
                         </div>
                       </li>
                       </template>
                       <template v-else >
                         no items scanned
                       </template>
                     </div>
                   </ul>
                  </div>

                  
              
              </div>
            </div>
          
          </swiper-slide>

          <swiper-slide>Slide 3

            <button class="btn btn-danger" @click="swipePrev">
                      prev
                    </button>
              <button class="btn btn-danger" @click="swipeNext">
                      finalizar
                    </button>
          </swiper-slide>
          
        </swiper-container>
      </div>
    </div>
  </AdminLayout>
</template>
