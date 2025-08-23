import { createApp, h } from 'vue';
import type { DefineComponent } from "vue";
import { createInertiaApp } from '@inertiajs/vue3';
import { resolvePageComponent } from 'laravel-vite-plugin/inertia-helpers';
import { createPinia } from 'pinia'

import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'


// Import css resources here instead in vite.config.ts under laravel settings
import './app.css';

import { register } from 'swiper/element/bundle';

register()



const appName = window.document.getElementsByTagName('title')[0]?.innerText || 'Inertia';

const pinia = createPinia()

library.add(fas)

await createInertiaApp({
  resolve: (name) =>
    resolvePageComponent(
      `./Pages/${name}.vue`,
      import.meta.glob<DefineComponent>('./Pages/**/*.vue')
    ),
  setup({el, App, props, plugin}) {
    createApp({render: () => h(App, props)})
      .use(plugin)
      .component('font-awesome-icon', FontAwesomeIcon)  
      .use(pinia)
      .mount(el);
  },
  title: (title) => `${title} - ${appName}`,
  progress: {
    color: '#4B5563',
  },
});