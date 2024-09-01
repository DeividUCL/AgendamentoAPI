import { defineNuxtConfig } from 'nuxt/config'
export default defineNuxtConfig({
  devtools: { enabled: false },
  css: [
    'primeflex/primeflex.css',
    'primevue/resources/themes/lara-dark-purple/theme.css',
    'primevue/resources/primevue.min.css',
    'primevue/resources/primevue.css',
    'primeicons/primeicons.css',
  ],
  build: {
    transpile: ['primevue']
  },
  modules: [
    '@nuxt/content',
    '@primevue/nuxt-module',
    '@pinia/nuxt'
  ],

  pinia: {
    storesDirs: ['~/stores/**']
  },

  primevue: {
    usePrimeVue: true
  },

  content: {
    locales: ['pt-br'],
  },

})