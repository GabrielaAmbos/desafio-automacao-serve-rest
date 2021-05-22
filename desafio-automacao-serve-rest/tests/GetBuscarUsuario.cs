

using desafio_automacao_serve_rest.client;
using desafio_automacao_serve_rest.models;
using desafio_automacao_serve_rest.utils.providers;
using FluentAssertions;
using NUnit.Framework;

namespace desafio_automacao_serve_rest.tests
{
    public class GetBuscarUsuario
    {
        [Test]
        public void DeveBuscarUsuario()
        {
            var json = ApiClient<User>.Request(Hooks.GetUsersEndpoint() + Hooks.GetId());

            json.Nome.Should().Be("Tomas Oliver");
            json.Email.Should().Be("tomas_oliver@gmail.com");
            json.Password.Should().Be("123456");
            json.Administrador.Should().Be("true");
            json.Id.Should().NotBeNull();
        }

        [Test]
        public void NaoDeveBuscarUsuario()
        {
            var json = ApiClient<User>.Request(Hooks.GetUsersEndpoint() + "/123");

            json.Message.Should().Be(MessageProvider.UsuarioNaoEncontrado());
        }
    }
}
