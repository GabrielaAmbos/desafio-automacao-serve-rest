using Newtonsoft.Json.Linq;

namespace desafio_automacao_serve_rest.utils.providers
{
    public class ProductProvider
    {
        public static string Nome()
        {
            return "Logitech";
        }

        public static string Preco()
        {
            return "470";
        }

        public static string Descricao()
        {
            return "Mouse";
        }

        public static string Quantidade()
        {
            return "301";
        }

        public static JObject CadastrarProduto()
        {
            JObject jObjectBody = new JObject();

            jObjectBody.Add("nome", Nome());
            jObjectBody.Add("preco", Preco());
            jObjectBody.Add("descricao", Descricao());
            jObjectBody.Add("quantidade", Quantidade());

            return jObjectBody;
        }
    }
}
