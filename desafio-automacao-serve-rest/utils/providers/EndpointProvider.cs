

namespace desafio_automacao_serve_rest.utils.providers
{
    public class EndpointProvider
    {
        public static string Users()
        {
            return UrlProvider.BaseUrl() + "/usuarios";
        }
    }
}
