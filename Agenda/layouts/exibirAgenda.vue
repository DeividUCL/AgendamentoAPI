<template>
    <div class="flex flex-col justify-between h-screen">
        <AppHeader />
        <div class="flex items-center justify-center">
            <UIcon name='i-heroicons-book-open' size="5rem" />
            <ULandingHero title="Agenda Disponível" description="Abaixo se encontra a agenda disponível, 
      verifique o dia desejado e o horário disponível." />
        </div>
        <slot></slot>
        <AppFooter />
    </div>
</template>
  