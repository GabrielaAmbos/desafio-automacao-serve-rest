
namespace desafio_automacao_serve_rest.utils.providers
{
    public class MessageProvider
    {
        public static string CadastroDeUsuarioComSucesso()
        {
            return "Cadastro realizado com sucesso";
        }

        public static string EmailJaCadastrado()
        {
            return "Este email já está sendo usado";
        }

        public static string UsuarioNaoEncontrado()
        {
            return "Usuário não encontrado";
        }
    }
}
