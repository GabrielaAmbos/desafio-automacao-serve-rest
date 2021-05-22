using desafio_automacao_serve_rest.client;
using desafio_automacao_serve_rest.models;
using desafio_automacao_serve_rest.utils.providers;
using NUnit.Framework;
using RestSharp;

namespace desafio_automacao_serve_rest.tests
{
    [SetUpFixture]
    public class Hooks
    {
        private static string LastUserId;
        private static string LastProductId;
        private static string LastToken;

        [OneTimeSetUp]
        public static void CriarDadosIniciais()
        {
            var jsonUser = ApiClient<User>.Request(GetUsersEndpoint(), Method.POST, UsuarioProvider.CriarUsuario());
            LastUserId = jsonUser.Id;

            var jsonLogin = ApiClient<Login>.Request(GetLoginEndpoint(), Method.POST, UsuarioProvider.RealizarLogin());
            LastToken = jsonLogin.Authorization;

            var jsonProduct = ApiClient<Product>.Request(GetProductId(), Method.POST, ProductProvider.CadastrarProduto(), LastToken);
            LastProductId = jsonProduct.Id;
        }


        public static string GetUserId()
        {
            return "/" + LastUserId;
        }

        public static string GetProductId()
        {
            return "/" + LastProductId;

        }

        public static string GetLastToken()
        {
            return LastToken;
        }

        public static string GetUsersEndpoint()
        {
            return EndpointProvider.Users();
        }

        public static string GetProdutsEndpoint()
        {
            return EndpointProvider.Products();
        }

        public static string GetLoginEndpoint()
        {
            return EndpointProvider.Login();
        }

        [OneTimeTearDown]
        public static void DeveExcluirDados()
        {
            string userEndpoint = GetUsersEndpoint() + GetUserId();
            string productEndpoint = GetProdutsEndpoint() + GetProductId();

            ApiClient<User>.Request(userEndpoint, Method.DELETE);
            ApiClient<Product>.Request(productEndpoint, Method.DELETE, null, GetLastToken());
        }
    }
}
