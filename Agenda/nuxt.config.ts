// https://nuxt.com/docs/api/configuration/nuxt-config
import { defineNuxtConfig } from 'nuxt/config'
export default defineNuxtConfig({
  devtools: { enabled: true },
  extends: ['@nuxt/ui-pro'],
  modules: [
    '@samk-dev/nuxt-vcalendar',
    '@nuxt/ui',
    'nuxt-icon',
    '@nuxt/content',
    ['nuxt-vue3-google-signin', {
      clientId: 'CLIENT ID OBTAINED FROM GOOGLE API CONSOLE',
    }],
  ],
  alias: {
    '~~': '/Agenda',
    '@@': '/Agenda',
  },
  content: {
    locales: ['pt-br'],
  }
})