using desafio_automacao_serve_rest.utils.providers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio_automacao_serve_rest.client
{
    public static class ApiClient<T>
    {
        public static T Request(string endpoint, Method method = Method.GET, JObject jObjectBody = null, string token = null)
        {
            RestClient restClient = new RestClient(UrlProvider.BaseUrl());
            RestRequest restRequest = new RestRequest(endpoint, method);

            if (method.Equals(Method.POST) || method.Equals(Method.PUT))
            {
                restRequest.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            }
            else
            {
                restRequest.AddParameter("application/json", ParameterType.RequestBody);
            }

            restRequest.AddHeader("Authorization", token);

            IRestResponse restResponse = restClient.Execute(restRequest);

            return JsonConvert.DeserializeObject<T>(restResponse.Content);
        }

    }
}
