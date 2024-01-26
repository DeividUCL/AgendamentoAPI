<script setup lang="ts">
import type { NavItem } from '@nuxt/content/dist/runtime/types/index'

// const navigation = inject<Ref<NavItem[]>>('navigation', ref([]))

const { data: navigation } = await useAsyncData('navigation', () => fetchContentNavigation(), { default: () => [] })

const links = [{
  label: 'Sobre',
  to: '/sobre',
  icon: 'i-heroicons-sun-20-solid'
}, {
  label: 'Agenda',
  icon: 'i-heroicons-book-open',
  to: '/agenda'
}, {
  label: 'Localização',
  to: 'https://github.com/nuxt/ui/releases',
  // target: '_blank'
}]
</script>

<template>
  <!-- <UAsideLinks  :links="links" /> -->
  <UHeader :links="links">
    <template #logo>
      <Logo />
    </template>

    <template #right>

      <UColorModeButton />

      <UButton to="https://github.com/nuxt/ui" target="_blank" icon="i-heroicons-sun-20-solid" color="DEFAULT"
        variant="ghost" />
    </template>

    <template #panel>
      <UNavigationTree :links="mapContentNavigation(navigation)" />
    </template>
  </UHeader>
</template>




 