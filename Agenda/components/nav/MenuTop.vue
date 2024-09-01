<template>
    <div class="card">
        <Menubar :model="pages">
            <template #item="slotProps">
                <NuxtLink v-if="slotProps.item.to" :to="slotProps.item.to" class="p-menuitem-link">
                    <span :class="['p-menuitem-icon', slotProps.item.icon]"></span>
                    {{ slotProps.item.label }}
                </NuxtLink>
                <span v-else :class="['p-menuitem-icon', slotProps.item.icon]">{{
            slotProps.item.label }}</span>
            </template>
            <template #end>
                <NavUserLogin />
                <NavNotificacao />
            </template>
        </Menubar>
    </div>
</template>

<script setup lang="ts">
const pages = ref([
    {
        label: 'Home',
        to: '/',
        icon: 'pi pi-home'
    },
    {
        label: 'Agenda',
        to: '/agenda',
        icon: 'pi pi-calendar-clock'
    },
    {
        label: 'Sobre',
        to: '/sobre',
        icon: 'pi pi-info'
    },
    {
        label: 'Contato',
        to: '/contato',
        icon: 'pi pi-envelope'
    }
]);
</script>