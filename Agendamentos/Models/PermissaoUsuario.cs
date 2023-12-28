namespace Agendamentos.Classes
{
	public class PermissaoUsuario : Permissao
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public Permissao Permissao { get; set; }

        public PermissaoUsuario(Permissao permissao)
        {
            Permissao = permissao;
        }

    }
}
