<script setup lang="ts">
import { StreamBarcodeReader } from "vue-barcode-reader";


const onDecode= ()=>{
    console.log('was decoded')
}

const onLoaded = () =>{
    console.log('was loaded')
}

</script>


<template>
    <h1>hola desde la venta crearte</h1>


    <StreamBarcodeReader @decode="onDecode" @loaded="onLoaded"></StreamBarcodeReader>

    
</template>