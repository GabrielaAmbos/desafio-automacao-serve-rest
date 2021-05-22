using desafio_automacao_serve_rest.client;
using desafio_automacao_serve_rest.models;
using desafio_automacao_serve_rest.utils.providers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;


namespace desafio_automacao_serve_rest.tests
{
    [SetUpFixture]
    public class Hooks
    {
        private static string LastUserId;

        [OneTimeSetUp]
        public static void CriarUsuario()
        {
            string endpoint = GetUsersEndpoint();

            JObject jObjectBody = new JObject();
            jObjectBody.Add("nome", UsuarioProvider.Nome());
            jObjectBody.Add("email", UsuarioProvider.Email());
            jObjectBody.Add("password", UsuarioProvider.Password());
            jObjectBody.Add("administrador", UsuarioProvider.Administrador());

            var json = ApiClient<User>.Request(endpoint, Method.POST, jObjectBody);

            LastUserId = json.Id;
        }


        public static string GetId()
        {
            return "/" + LastUserId;
        }

        public static string GetUsersEndpoint()
        {
            return EndpointProvider.Users();
        }

        [OneTimeTearDown]
        public static void DeveExcluirUsuario()
        {
            string endpoint = GetUsersEndpoint() + GetId();

            var json = ApiClient<User>.Request(endpoint, Method.DELETE);
        }
    }
}
