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
            var json = ApiClient<User>.Request(Hooks.GetUsersEndpoint() + Hooks.GetUserId());

            json.Nome.Should().Be(UsuarioProvider.Nome());
            json.Email.Should().Be(UsuarioProvider.Email());
            json.Password.Should().Be(UsuarioProvider.Password());
            json.Administrador.Should().Be(UsuarioProvider.Administrador());
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
