using desafio_automacao_serve_rest.client;
using desafio_automacao_serve_rest.models;
using desafio_automacao_serve_rest.utils.providers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace desafio_automacao_serve_rest.tests
{
    
    public class PostCadastrarProduto
    {
        private string LastProductId;

        [Test]
        public void DeveCadastrarUmProduto()
        {
            JObject jObject = new JObject();

            jObject.Add("nome", "Notebook LG Gram Intel Core i7-1165G7, 16GB, 512GB SSD, Windows 10, Preto");
            jObject.Add("preco", "1199");
            jObject.Add("descricao", "Notebook");
            jObject.Add("quantidade", "501");

            var json = ApiClient<Product>.Request(Hooks.GetProdutsEndpoint(), Method.POST, jObject, Hooks.GetLastToken());

            LastProductId = json.Id;
            json.Message.Should().Be(MessageProvider.CadastroDeProdutoComSucesso());
            json.Id.Should().NotBeNull();
        }

        [Test]
        public void NaoDeveCadastrarUmProdutoJaCadastrado()
        {
            JObject jObject = new JObject();

            jObject.Add("nome", ProductProvider.Nome());
            jObject.Add("preco", ProductProvider.Preco());
            jObject.Add("descricao", ProductProvider.Descricao());
            jObject.Add("quantidade", ProductProvider.Quantidade());

            var json = ApiClient<Product>.Request(Hooks.GetProdutsEndpoint(), Method.POST, jObject, Hooks.GetLastToken());

            LastProductId = json.Id;
            json.Message.Should().Be(MessageProvider.JaExisteUmProdutoComEsseNome());
        }

        [Test]
        public void NaoDeveCadastrarUmProdutoSemToken()
        {
            JObject jObject = new JObject();

            jObject.Add("nome", ProductProvider.Nome());
            jObject.Add("preco", ProductProvider.Preco());
            jObject.Add("descricao", ProductProvider.Descricao());
            jObject.Add("quantidade", ProductProvider.Quantidade());

            var json = ApiClient<Product>.Request(Hooks.GetProdutsEndpoint(), Method.POST, jObject);

            LastProductId = json.Id;
            json.Message.Should().Be(MessageProvider.TokenAusenteInvalidoOuExpirado());
        }

        [TearDown]
        public void DeveExcluirProdutoExistente()
        {
            string endpoint = Hooks.GetProdutsEndpoint() + "/" + LastProductId;

            var json = ApiClient<Product>.Request(endpoint, Method.DELETE, null, Hooks.GetLastToken());
        }
    }
}
