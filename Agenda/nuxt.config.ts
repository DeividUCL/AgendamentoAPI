// https://nuxt.com/docs/api/configuration/nuxt-config
import { defineNuxtConfig } from 'nuxt/config'
export default defineNuxtConfig({
  devtools: { enabled: false },
  extends: ['@nuxt/ui-pro'],
  modules: [
    '@nuxt/ui',
    '@nuxt/content',
    ['nuxt-vue3-google-signin', {
      clientId: 'CLIENT ID OBTAINED FROM GOOGLE API CONSOLE',
    }],
  ],
  content: {
    locales: ['pt-br'],
  }
})