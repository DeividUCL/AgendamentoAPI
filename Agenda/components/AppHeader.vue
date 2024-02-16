<script setup lang="ts">
const { data: navigation } = await useAsyncData('navigation', () => fetchContentNavigation(), { default: () => [] })

const links = [{
  label: 'Sobre',
  to: '/sobre',
}, {
  label: 'Agenda',
  to: '/agenda',
}, {
  label: 'Entrar',
  children: [{
    label: 'Cadastro',
    to: '/Cadastro',
  }, {
    label: 'Login',
    to: '/login',
  }]
}]
</script>

<template>
  <!-- <UAsideLinks  :links="links" /> -->
  <UHeader :links="links">
    <template #logo>
      <Logo />
    </template>

    <template #right>
      <!-- <ColorPicker /> -->

      <UColorModeButton />
    </template>

    <template #panel>
      <UNavigationTree :links="mapContentNavigation(navigation)" />
    </template>
  </UHeader>
</template>




 