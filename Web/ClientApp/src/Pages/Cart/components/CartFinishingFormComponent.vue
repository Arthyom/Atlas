<script setup lang="ts">
import IAtlasProducto, {
  IAtlasDtoProducto,
} from "@/Models/Entities/IAtlasProducto";
import { string } from "yup";
import { ICartDireccion, ICartMetodoPago } from "../interfaces/CartDireccion.interface";

const props = defineProps<{direccion?:ICartDireccion, metodoPago?:ICartMetodoPago,  products?: IAtlasDtoProducto[], total: number }>();

const hideString = (source?:string, toShowLast:number = 4, replaceChar: string = '*') =>{
  if(!source) return ''
  
  const sourceLeng = source.length;

  return [...source].map( (x,i) => {
    if(x !== ' ' && i <= sourceLeng -1 -toShowLast)
      return replaceChar
    else
      return x
  }).join().replaceAll(',','')
}
</script>

<template>
  <div class="px-4 mt-6">
    <h1 class="text-2xl font-bold text-center">Revision</h1>

    <div class="grid grid-cols-1 gap-4">
      <div class="card w-full bg-base-100 card-sm shadow-sm">
        <div class="card-body">
          <div class="card-title flex w-full">
            <span class="">Direccion</span>
            <div class="flex justify-end w-full">
              <button
                @click="$emit('editAt', 1)"
                class="btn btn-sm btn-ghost text-blue-800 justify-end"
              >
                <font-awesome-icon icon="fas fa-edit"></font-awesome-icon>
              </button>
            </div>
          </div>
          <div class="flex flex-col">
            <div>
              <span>
                {{ direccion?.direccion }} <b>#</b>{{ direccion?.exterior  }}
                <span class="m-2" v-if="!!direccion?.interior"><b>Int: </b>{{ direccion?.interior }}</span>
              </span>
              <span class="m-2">
                <b >Colonia: </b>{{ direccion?.coloniaId }} <span class="m-2"><b>CP: </b>{{ direccion?.cp }}</span>
              </span>
            </div>

            <span v-if="!!direccion?.entreCalles">
              <b>Entre Calles:</b> {{ direccion?.entreCalles }}
            </span>
           


              {{ direccion?.municipioId }}, {{ direccion?.estadoId }}, {{ direccion?.paisId }}


          </div>
        </div>
      </div>

      <div class="card w-full bg-base-100 card-sm shadow-sm">
        <div class="card-body">
          <div class="card-title flex w-full">
            <span class="flex-1">Metodo de Pago</span>
            <div class="flex justify-end">
              <button
                @click="$emit('editAt', 2)"
                class="btn btn-sm btn-ghost text-blue-800 justify-end"
              >
                <font-awesome-icon icon="fas fa-edit"></font-awesome-icon>
              </button>
            </div>
          </div>
          <div class="flex flex-col">
            <div>
              {{ metodoPago?.metodoPagoId }}
            </div>
            <span>
              <b>A nombre de: </b>{{ metodoPago?.titular }} 
            </span>
            <span>
              <b>
                Numero:
              </b>
              {{ hideString( metodoPago?.numero.toString()   ) }}
            </span>
          </div>
        </div>
      </div>

      <div class="card w-full bg-base-100 card-sm shadow-sm">
        <div class="card-body">
          <div class="card-title flex w-full">
            <span class="flex-1">Detalle de Productos</span>
            <div class="flex justify-end">
              <button
                @click="$emit('editAt', 0)"
                class="btn btn-sm btn-ghost text-blue-800 justify-end"
              >
                <font-awesome-icon icon="fas fa-edit"></font-awesome-icon>
              </button>
            </div>
          </div>

          <div class="  ">
            <table
              class="table table-xs table-pin-rows table-pin-cols text-center"
            >
              <thead>
                <tr>
                  <td>Producto</td>
                  <td>Cantidad</td>
                  <td>Precio</td>
                  <td>Subtotal</td>
                </tr>
              </thead>
              <tbody>
                <tr v-for="prop in props.products">
                  <td>{{ prop.nombre }}</td>
                  <td>{{ prop.cantidad }}</td>
                  <td>{{ prop.precioMayoreo }}</td>
                  <td>{{ prop.precioMayoreo * prop.cantidad }}</td>
                </tr>
                
                <tr>
                  <td></td>
                  <td></td>
                  <td><b>SubTotal</b></td>
                  <td><b>{{ total }}</b></td>
                </tr>
              </tbody>

              
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
