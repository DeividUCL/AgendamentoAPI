<template>
    <div class="flex items-center">
        <UColorModeImage :light="light" :dark="dark" class="w-auto h-12" />
        <p class="pl-2 font-black tracking-widest text-xl text-cool-500 dark:text-cool-400" alt="Agenda do Barbeiro">
            AgendaDoBarbeiro
        </p>
    </div>
</template>
  
<script setup lang="ts">
const light = '/logo/2-1.png'
const dark = '/logo/2dark.png'
</script>