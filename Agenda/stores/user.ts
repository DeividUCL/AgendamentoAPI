import { defineStore } from 'pinia';

interface Usuario {
  id: number;
  username: string;
  nome: string;
  email: string;
  telefone: string;
}

export const useUserStore = defineStore('usuario', {
  state: () => ({
    isAuthenticated: false,
    usuario: null as { nome: string } | null,
  }),
  actions: {
    login(usuario: Usuario, token: string) {
      this.isAuthenticated = true;
      this.usuario = usuario;
      localStorage.setItem('token', token);
      localStorage.setItem('userId', usuario.id.toString());
      console.log('Estado de autenticação atualizado:', this.isAuthenticated);
    },
    logout() {
      this.isAuthenticated = false;
      this.usuario = null;
      localStorage.removeItem('token');
      localStorage.removeItem('userId');
      console.log('Usuário deslogado');
    },
  },
});