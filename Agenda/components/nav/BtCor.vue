<template>
    <ClientOnly>
        <UButton :icon="isEscuro ? 'i-heroicons-moon-20-solid' : 'i-heroicons-sun-20-solid'" color="gray" variant="ghost"
            aria-label="Theme" @click="isEscuro = !isEscuro" />

        <template #fallback>
            <div class="w-8 h-8" />
        </template>
    </ClientOnly>
</template>

<script setup lang="ts">
const colorMode = useColorMode()

const isEscuro = computed({
    get() {
        return colorMode.value === 'escuro'
    },
    set() {
        colorMode.preference = colorMode.value === 'escuro' ? 'claro' : 'escuro'
    }
})
</script>

<style scoped></style>