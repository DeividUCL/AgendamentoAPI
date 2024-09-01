<template>
  <button type="button" class="topbar-item config-item" data-pd-styleclass="true" @click="showModal = true">
    <i class="pi pi-palette"></i>
  </button>

  <Dialog v-model:visible="showModal" :modal="true" :closable="true">
    <h2>Selecione um tema</h2>
    <div v-for="theme in themes" :key="theme">
      <button @click="changeTheme(theme)">{{ theme }}</button>
    </div>
  </Dialog>
</template>

<script setup lang="ts">

const themes = [
  'md-light-indigo',
  'md-dark-indigo',
  'md-dark-deeppurple',
  'mdc-light-indigo',
  'mdc-light-deeppurple',
  'mdc-dark-indigo',
  'mdc-dark-deeppurple',
  'aura-light-blue',
  'aura-light-indigo',
  'aura-light-purple',
  'aura-light-teal',
  'aura-light-green',
  'aura-light-amber',
  'aura-light-cyan',
  'aura-light-pink',
  'aura-light-lime',
  'aura-light-noir',
  'aura-dark-blue',
  'aura-dark-indigo',
  'aura-dark-purple',
  'aura-dark-teal',
  'aura-dark-green',
  'aura-dark-amber',
  'aura-dark-cyan',
  'aura-dark-pink',
  'aura-dark-lime',
  'aura-dark-noir',
  'lara-light-blue',
  'lara-light-indigo',
  'lara-light-purple',
  'lara-light-teal',
  'lara-light-green',
  'lara-light-amber',
  'lara-light-cyan',
  'lara-light-pink',
  'lara-dark-blue',
  'lara-dark-indigo',
  'lara-dark-purple',
  'lara-dark-teal',
  'lara-dark-green',
  'lara-dark-amber',
  'lara-dark-cyan',
  'lara-dark-pink',
];
let themeIndex = ref(0);
const currentTheme = ref(themes[themeIndex.value]);
const showModal = ref(false);

const changeTheme = (theme: string) => {
  themeIndex.value = themes.indexOf(theme);
  currentTheme.value = theme;
  if (typeof window !== 'undefined') {
    localStorage.setItem('theme', theme);
  }
  showModal.value = false;
};

if (typeof window !== 'undefined') {
  const userTheme = localStorage.getItem('theme');
  if (userTheme) {
    currentTheme.value = userTheme;
    themeIndex.value = themes.indexOf(userTheme);
  }
}

watchEffect(() => {
  if (typeof window !== 'undefined') {
    const linkElement = document.getElementById('theme-css');
    if (linkElement instanceof HTMLLinkElement) {
      linkElement.href = `${window.location.origin}/primevue/resources/themes/${currentTheme.value}/theme.css`;
    } else {
      const newLinkElement = document.createElement('link');
      newLinkElement.id = 'theme-css';
      newLinkElement.rel = 'stylesheet';
      newLinkElement.href = `${window.location.origin}/primevue/resources/themes/${currentTheme.value}/theme.css`;
      document.head.appendChild(newLinkElement);
    }
  }
});
</script>