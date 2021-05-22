
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

        public static string CadastroDeProdutoComSucesso()
        {
            return "Cadastro realizado com sucesso";
        }

        public static string JaExisteUmProdutoComEsseNome()
        {
            return "Já existe produto com esse nome";
        }

        public static string TokenAusenteInvalidoOuExpirado()
        {
            return "Token de acesso ausente, inválido, expirado ou usuário do token não existe mais";
        }

        public static string ProdutoNaoEncontrado()
        {
            return "Produto não encontrado";
        }
    }
}
