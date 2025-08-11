<script setup lang="ts">
import { useAtlasComposableUseFilesFetcher } from "@/Models/Composables/AtlasComposableFilesFetcher";
import { useAtlasComposableLoadingCallbacks } from "@/Models/Composables/AtlasComposableLoadingCallbacks";
import { IAtlasDtoProducto } from "@/Models/Entities/IAtlasProducto";
import { AtlasHelperProducto } from "@/Models/Helpers/AtlasHelper";
import IAtlasCustomTableConfig from "@/Models/Interfaces/IAtlasCustomTableConfig";
import IAtlasCustomTemplateWrapper from "@/Models/Interfaces/IAtlasCustomTemplateWrapper";
import { IAtlasKeyValue } from "@/Models/Interfaces/IAtlasKeyValue";
import IAtlasMixedResponse from "@/Models/Interfaces/IAtlasMixedResponse";
import AdminLayout from "@/Pages/admin/layout/AdminLayout.vue";
import AtlasCustomImageStack from "@/Pages/Shared/Components/AtlasCustomImageStack.vue";
import AtlasTableActions from "@/Pages/Shared/Components/AtlasTableActions.vue";
import AtlasTableWrapper from "@/Pages/Shared/Components/AtlasTableWrapper.vue";
import { useForm, usePage } from "@inertiajs/vue3";
import axios from "axios";
import { stringify } from "postcss";
import { computed, InputTypeHTMLAttribute, ref, h } from "vue";
import { saveAs } from "file-saver";

const areAllChecked = ref<boolean>(false);
const props = defineProps<IAtlasMixedResponse<IAtlasDtoProducto>>();

const { getFirstFileForProducto, noFile } = useAtlasComposableUseFilesFetcher();

console.log("ssssss", props);
const tableConfig: IAtlasCustomTableConfig = {
  configs: {
    headersLabels: ["Titulo", "Modelo"],
    resource: "producto",
    title: "Listado de productos",
  },
};

const mode = ref("admin");

const toggleProducts = () => {
  // const {checked} = (event.target as HTMLInputElement);

  if (props.mainResource) props.mainResource.selected = areAllChecked.value;

  props.mainResourceCollection.forEach(
    (x) => (x.selected = areAllChecked.value)
  );
};

const cleanSelected = () => {
  areAllChecked.value = false;
  props.mainResourceCollection.forEach(
    (x) => (x.selected = areAllChecked.value)
  );
};

const createBarCodes = async () => {
  const { opts } = useAtlasComposableLoadingCallbacks();

  if (!props.mainResourceCollection.find((x) => x.selected)) {
    alert("no codes selected");
    return;
  }

  if (!props.mainResourceCollection) return;
  const keyValueProductsMapped = AtlasHelperProducto.getSelectedProducts(
    props.mainResourceCollection
  );
  const form = useForm({ items: keyValueProductsMapped });
  opts.onStart({});

  try {
    const response = await axios.post(
      "/admin/producto/barcode",
      { items: keyValueProductsMapped },
      { responseType: "blob" }
    );

    const url = window.URL.createObjectURL(
      new Blob([response.data], { type: "application/pdf" })
    );

    window.open(url, "_blank");

    URL.revokeObjectURL(url);
  } catch (error) {
    opts.onError({});
    alert("eror");
  } finally {
    opts.onFinish({});
    cleanSelected();
  }
};
</script>

<template>
  <AdminLayout>
    <AtlasTableWrapper :configs="tableConfig.configs">
      <template v-slot:customTh>
        <th class="">
          <label>
            <input
              type="checkbox"
              class="checkbox"
              @change="toggleProducts"
              v-model="areAllChecked"
            />
          </label>
        </th>
      </template>

      <template v-slot:buttonSlot>
        <div class="hidden lg:flex mr-4">
          <button class="btn btn-secondary avatar mr-4" @click="createBarCodes">
            Playeras
          </button>

          <button class="btn btn-primary avatar mr-4" @click="createBarCodes">
            Mochilas
          </button>

          <button class="btn btn-accent avatar mr-4" @click="createBarCodes">
            Gorras
          </button>
        </div>

        <button class="btn btn-base avatar mr-4" @click="createBarCodes">
          <font-awesome-icon icon="fas fa-table-cells"></font-awesome-icon>
        </button>
      </template>

      <template v-slot:default>
        <template v-for="resource in props.mainResourceCollection">
          <tr>
            <td>
              <label>
                <input
                  type="checkbox"
                  class="checkbox"
                  v-model="resource.selected"
                />
              </label>
            </td>

            <td class="">
              <!-- Big screens sections -->
              <div class="hidden lg:flex items-center gap-3">
                <div class=" ">
                  <div class="absolute z-50">
                    <button
                      class="btn btn-xs md:btn-sm lg:btn-md btn-base-100 btn-circle items-center"
                      :class="
                        { 
                          'btn-error' : resource.existencia! <= resource.existenciaMaxima!,
                          'btn-info' : resource.existencia! >= resource.existenciaMaxima!,
                        }
                        "
                      
                    >
                      {{ resource.existencia }}
                    </button>
                  </div>

                  <div class="avatar-group bg-blck w-full">
                    <div class="avatar border-accent">
                      <div class="w-20 md:w-30 lg:w-42">
                        <img
                          class=""
                          :src="getFirstFileForProducto(resource, mode)"
                        />
                      </div>
                    </div>
                  </div>
                </div>

                <div class="flex flex-col bg--400 w-full">
                  <div
                    class="text-sm md:text-xl lg:text-2xl font-extrabold md:font-bold mb-2"
                  >
                    {{ resource.nombre }}
                  </div>

                  <div class="grid grid-cols-2 b-red-500 pl-1 gap-y-2">
                    <div class="text-xs md:text-xl lg:text-2xl">
                      <div class="tooltip" data-tip="Unitario">
                        <font-awesome-icon
                          icon="fa-solid fa-bag-shopping"
                          class="mr-1"
                        />
                        {{ resource.precioUnitario }}
                      </div>
                    </div>

                    <div class="text-xs md:text-xl lg:text-2xl">
                      <div class="tooltip" data-tip="Mayoreo">
                        <font-awesome-icon
                          icon="fa-solid fa-dolly"
                          class="mr-1"
                        />
                        <span class=""> {{ resource.precioMayoreo }}</span>
                      </div>
                    </div>

                    <div class="text-xs md:text-xl lg:text-2xl">
                      <div class="tooltip" data-tip="Minima">
                        <font-awesome-icon
                          icon="fa-solid fa-down-long"
                          class="mr-3 text-error"
                        />
                        <span class=""> {{ resource.existenciaMinima }}</span>
                      </div>
                    </div>

                    <div class="text-xs md:text-xl lg:text-2xl">
                      <div class="tooltip" data-tip="Minima">
                        <font-awesome-icon
                          icon="fa-solid fa-up-long"
                          class="text-info mr-2"
                        />
                        <span> {{ resource.existenciaMaxima }}</span>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <!-- Small screens sections -->
              <div
                class="lg:hidden bg-base-300 border-base-300 shadow-x collapse border"
              >
                <input type="checkbox" class="peer" />

                <div
                  class="p-2 collapse-title peer-checked:bg-black peer-checked:text-white"
                >
                  <div class="flex flex-col items-center gap-2">
                    <div class="text-xl w-full font-bold">
                      {{ resource.nombre }}
                    </div>

                    <div class="flex w-full">
                      <div class="">
                        <div class="absolute top-10 left-1 z-50">
                          <button
                            class="btn btn-base-100 btn-circle items-center"

                            :class="
                        { 
                          'btn-error' : resource.existencia! <= resource.existenciaMaxima!,
                          'btn-info' : resource.existencia! >= resource.existenciaMaxima!,
                        }
                        "
              
              

                          >
                            {{ resource.existencia }}
                          </button>
                        </div>

                        <div class="avatar-group bg-blck w-full">
                          <div class="avatar border-accent">
                            <div class="w-20 md:w-30 lg:w-42">
                              <img
                                class=""
                                :src="getFirstFileForProducto(resource, mode)"
                              />
                            </div>
                          </div>
                        </div>
                      </div>

                      <div class="flex justify-center items-center ml-3 w-full">
                        <AtlasCustomImageStack v-bind="resource" />
                      </div>
                    </div>

                    <div class="grid grid-cols-4 w-full font-bold text-lg">
                      <div class="">
                        <div class="tooltip" data-tip="Unitario">
                          <font-awesome-icon
                            icon="fa-solid fa-bag-shopping"
                            class="mr-1"
                          />
                          {{ resource.precioUnitario }}
                        </div>
                      </div>

                      <div class="">
                        <div class="tooltip" data-tip="Mayoreo">
                          <font-awesome-icon
                            icon="fa-solid fa-dolly"
                            class="mr-1"
                          />
                          <span class=""> {{ resource.precioMayoreo }}</span>
                        </div>
                      </div>

                      <div class="text-end">
                        <div class="tooltip" data-tip="Minima">
                          <font-awesome-icon
                            icon="fa-solid fa-down-long"
                            class="mr-3 text-error"
                          />
                          <span class=""> {{ resource.existenciaMinima }}</span>
                        </div>
                      </div>

                      <div class="text-end">
                        <div class="tooltip" data-tip="Minima">
                          <font-awesome-icon
                            icon="fa-solid fa-up-long"
                            class="text-info mr-2"
                          />
                          <span> {{ resource.existenciaMaxima }}</span>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="collapse-content">
                  <div class="mt-4">
                    <AtlasTableActions :id="resource.id">
                      <div class="tooltip" data-tip="Etiqueta">
                        <button
                          class="btn bnt-info"
                          @click="
                            resource.selected = true;
                            createBarCodes();
                          "
                        >
                          <font-awesome-icon
                            icon="fa-solid fa-barcode"
                          ></font-awesome-icon>
                        </button>
                      </div>
                    </AtlasTableActions>
                  </div>
                </div>
              </div>
            </td>

            <td class="hidden lg:table-cell">
              <AtlasCustomImageStack v-bind="resource" />
            </td>

            <td class="hidden lg:table-cell">
              <AtlasTableActions :id="resource.id">
                <div class="tooltip" data-tip="Etiqueta">
                  <button
                    class="btn bnt-info"
                    @click="
                      resource.selected = true;
                      createBarCodes();
                    "
                  >
                    <font-awesome-icon
                      icon="fa-solid fa-barcode"
                    ></font-awesome-icon>
                  </button>
                </div>
              </AtlasTableActions>
            </td>
          </tr>
        </template>
      </template>
    </AtlasTableWrapper>
  </AdminLayout>
</template>
