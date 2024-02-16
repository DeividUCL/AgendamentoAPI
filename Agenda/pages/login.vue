<script setup lang="ts">
import type { FormError } from '#ui/types'

const fields = [{
    name: 'email',
    type: 'text',
    label: 'Email',
    placeholder: 'Escreva seu email'
}, {
    name: 'password',
    label: 'Password',
    type: 'password',
    placeholder: 'Escreva sua senha'
}]

const validate = (state: any) => {
    const errors: FormError[] = []
    if (!state.email) errors.push({ path: 'email', message: 'Email obrigatorio' })
    if (!state.password) errors.push({ path: 'password', message: 'Senha obrigatoria' })
    return errors
}

// Login com Google //

// const providers = [{
//     label: 'Efetue login com Google',
//     icon: 'i-simple-icons-google',
//     color: 'black' as const,
//     click: () => {
//         console.log('Redirect to Google')
//     }
// }]

function onSubmit(data: any) {
    console.log('Login', data)
}
</script>

<template>
    <div class="flex items-center justify-center h-auto px-4 py-6 sm:px-6 lg:px-8">
        <UCard class="max-w-sm w-full">
            <UAuthForm class="" :fields="fields" :validate="validate" title="Seja bem vindo!" align="top"
                icon="i-heroicons-lock-closed" :ui="{ base: 'text-center', footer: 'text-center' }"
                :submitButton="{ label: 'Entrar' }" divider="AgendaDoBarbeiro" @submit="onSubmit">
                <template #description>
                    Ainda não possui conta? <NuxtLink to="/" class="text-primary font-medium">Cadastro</NuxtLink>.
                </template>

                <template #password-hint>
                    <NuxtLink to="/" class="text-primary font-medium">Esqueceu a senha?</NuxtLink>
                </template>

                <template #footer>
                    <div class="text-xs">
                        Ao fazer login, você concorda com nossos <NuxtLink to="/" class="text-primary font-medium">Termos de
                            Serviço
                        </NuxtLink>.
                    </div>
                </template>
            </UAuthForm>
        </UCard>
    </div>
</template>
