<script setup lang="ts">
import { useRouter } from '#app';
import { useUserStore } from '~/stores/user';

const router = useRouter();
const userStore = useUserStore();

onMounted(async () => {
  if (!userStore.isAuthenticated || !userStore.usuario) {
    router.push('/login');
  } else {
    console.log('Usuário:', userStore.usuario?.nome);
  }
});
</script>

<template>
  <h2>Perfil</h2>
  <div v-if="userStore.usuario">
    <h1>Bem-vindo, {{ userStore.usuario?.nome }}!</h1>
  </div>
</template>
