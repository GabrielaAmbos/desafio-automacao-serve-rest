

namespace desafio_automacao_serve_rest.utils.providers
{
    public class EndpointProvider
    {
        public static string Users()
        {
            return UrlProvider.BaseUrl() + "/usuarios";
        }

        public static string Products()
        {
            return UrlProvider.BaseUrl() + "/produtos";
        }

        public static string Login()
        {
            return UrlProvider.BaseUrl() + "/login";
        }
    }
}
