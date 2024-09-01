<script setup lang="ts">
import { loginUse } from '~/middleware/authentication';
import { useUserStore } from '~/stores/user';

const userStore = useUserStore();
const username = ref('')
const senha = ref('')
const errorMessage = ref('');


const handleSubmit = async () => {
    console.log('Tentando fazer login com log handleSubmit:', { username: username.value, senha: senha.value });
    try {
        await loginUse(
            username.value,
            senha.value
        );
        errorMessage.value = '';
        console.log('Login bem-sucedido, redirecionando...');
    } catch (error) {
        console.error('Erro ao tentar fazer login:', error);
        errorMessage.value = 'Erro ao acessar. Verifique o login e senha.';
    }
}

const logout = () => {
    userStore.logout();
};

const conectado = computed(() => userStore.isAuthenticated);
</script>

<template>
    <div class="login">
        <Card>
            <template #header>
                <div class="flex justify-content-center align-items-center">
                    <img class="p-4" alt="login header" src="../public/fingerprint-identity.jpg" />
                </div>
            </template>
            <template #title>Acesse a Agenda</template>
            <template #subtitle>Barbearia Alfa</template>
            <template #content>
                <p class="m-0">
                <div>
                    <form v-if="!conectado" @submit.prevent="handleSubmit">
                        <InputText v-model="username" type="text" placeholder="Login" required />
                        <br /><br />
                        <Password v-model="senha" promptLabel="insira a senha." type="password" placeholder="Senha"
                            required toggleMask />
                        <br /><br />
                        <Button type="submit">Entrar</Button>
                    </form>
                    <div v-else>
                        <p>Bem-vindo, {{ userStore.usuario?.nome }}!</p>
                        <Button @click="logout">Sair</Button>
                    </div>
                    <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
                </div>
                </p>
            </template>
            <template #footer>
                <div class="flex justify-content-center gap-3">
                    <NuxtLink class="no-underline" to="/cadastro">
                        Cadastre-se
                        <Avatar icon="pi pi-user" size="normal" />
                    </NuxtLink>
                </div>
            </template>
        </Card>
    </div>
</template>

<style scoped>
.login {
    display: flex;
    justify-content: center;
    align-items: center;
    height: calc(100vh - 200px);
}

.error {
    color: red;
}
</style>
