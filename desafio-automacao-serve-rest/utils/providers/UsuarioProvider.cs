using Newtonsoft.Json.Linq;


namespace desafio_automacao_serve_rest.utils.providers
{
    public class UsuarioProvider
    {
        public static string Nome()
        {
            return "Tomas Oliver";
        }

        public static string Email()
        {
            return "tomasoliver@qatest.com";
        }

        public static string Password()
        {
            return "123456";
        }

        public static string Administrador()
        {
            return "true";
        }

        public static JObject CriarUsuario()
        {
            JObject jObjectBody = new JObject();

            jObjectBody.Add("nome", Nome());
            jObjectBody.Add("email", Email());
            jObjectBody.Add("password", Password());
            jObjectBody.Add("administrador", Administrador());

            return jObjectBody;
        }

        public static JObject RealizarLogin()
        {
            JObject jObjectBody = new JObject();

            jObjectBody.Add("email", Email());
            jObjectBody.Add("password", Password());

            return jObjectBody;
        }
    }
}
