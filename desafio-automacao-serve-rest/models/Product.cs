using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio_automacao_serve_rest.models
{
    public class Product
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("preco")]
        public string Preco { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("quantidade")]
        public string Quantidade { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
