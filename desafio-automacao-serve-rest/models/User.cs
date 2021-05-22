using Newtonsoft.Json;

namespace desafio_automacao_serve_rest.models
{
    public class User
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("_id")]
        public string Id {get; set;}

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("administrador")]
        public string Administrador { get; set; }

    }
}
