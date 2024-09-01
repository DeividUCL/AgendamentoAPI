import { useRouter } from "#app";
import { useUserStore } from "~/stores/user";

interface LoginResponse {
  token: string;
  usuario: {
    id: number;
    username: string;
    nome: string;
    email: string;
    telefone: string;
  };
}

export async function loginUse(username: string, senha: string): Promise<void> {
  const router = useRouter();
  const userStore = useUserStore();
  try {
    console.log('Enviando solicitação de login...');
    const data = await $fetch<LoginResponse>('http://localhost:5267/v1/login', {
      method: 'POST',
      body: JSON.stringify({ username, senha }),
      headers: {
        'Content-Type': 'application/json'
      }
    });

    console.log('Resposta da API:', data);

    const token = data.token;
    const usuarioLogado = data.usuario;
    if (token && usuarioLogado) {
      userStore.login(usuarioLogado, token);
      console.log('Token e dados do usuário armazenados:', token, usuarioLogado);
      console.log('Redirecionando para /dashboard/perfil');
      await router.push('/dashboard/perfil');
    } else {
      console.error('Erro ao tentar fazer login: Dados de autenticação inválidos');
      throw new Error('Dados de autenticação inválidos');
    }
  } catch (error) {
    console.error('Erro ao tentar fazer login:', error);
    throw error;
  }
};

export function isAuthenticated(): boolean {
  const token = localStorage.getItem('token');
  return !!token;
}

export default defineNuxtRouteMiddleware(async (to, from) => {
  if (!isAuthenticated() && to.path !== '/login') {
    return navigateTo('/login');
  }
});