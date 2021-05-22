using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio_automacao_serve_rest.models
{
    public class Login
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("authorization")]
        public string Authorization { get; set; }
    }
}
