using desafio_automacao_serve_rest.client;
using desafio_automacao_serve_rest.models;
using desafio_automacao_serve_rest.utils.providers;
using FluentAssertions;
using NUnit.Framework;

namespace desafio_automacao_serve_rest.tests
{
    public class GetBuscarProduto
    {
        [Test]
        public void DeveBuscarPorUmProduto()
        {
            var json = ApiClient<Product>.Request(Hooks.GetProdutsEndpoint() + Hooks.GetProductId());

            json.Nome.Should().Be(ProductProvider.Nome());
            json.Preco.Should().Be(ProductProvider.Preco());
            json.Descricao.Should().Be(ProductProvider.Descricao());
            json.Quantidade.Should().Be(ProductProvider.Quantidade());
            json.Id.Should().NotBeNull();
        }

        [Test]
        public void NaoDeveBuscarPorUmProduto()
        {
            var json = ApiClient<Product>.Request(Hooks.GetProdutsEndpoint() + "/132");

            json.Message.Should().Be(MessageProvider.ProdutoNaoEncontrado());

        }
    }
}
