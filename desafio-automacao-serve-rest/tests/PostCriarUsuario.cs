using desafio_automacao_serve_rest.client;
using desafio_automacao_serve_rest.models;
using desafio_automacao_serve_rest.utils.providers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace desafio_automacao_serve_rest.tests
{
    public class PostCriarUsuario
    {
        private string LastUserId;

        [Test]
        public void DeveCriarUmUsuario()
        {
            JObject jObjectBody = new JObject();
            jObjectBody.Add("nome", "Tomas Oliver");
            jObjectBody.Add("email", "tomas_oliver123@outlook.com");
            jObjectBody.Add("password", "123456");
            jObjectBody.Add("administrador", "true");

            var json = ApiClient<User>.Request(Hooks.GetUsersEndpoint(), Method.POST, jObjectBody);

            LastUserId = json.Id;
            json.Message.Should().Be(MessageProvider.CadastroDeUsuarioComSucesso());
            json.Id.Should().NotBeNull();
        }

        [Test]
        public void NaoDeveCriarUmUsuarioComEmailJaUtilizado()
        {
            JObject jObjectBody = new JObject();
            jObjectBody.Add("nome", "Tomas Oliver");
            jObjectBody.Add("email", "tomas_oliver@gmail.com");
            jObjectBody.Add("password", "123456");
            jObjectBody.Add("administrador", "true");

            var json = ApiClient<User>.Request(Hooks.GetUsersEndpoint(), Method.POST, jObjectBody);

            LastUserId = json.Id;
            json.Message.Should().Be(MessageProvider.EmailJaCadastrado());
        }

        [TearDown]
        public void DeveExcluirUsuarioExistente()
        {
            string endpoint = Hooks.GetUsersEndpoint() + "/" + LastUserId;

            var json = ApiClient<User>.Request(endpoint, Method.DELETE);
        }
    }
}
