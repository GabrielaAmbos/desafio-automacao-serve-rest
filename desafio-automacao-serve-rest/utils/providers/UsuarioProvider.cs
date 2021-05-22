using System;
using System.Collections.Generic;
using System.Text;

namespace desafio_automacao_serve_rest.utils.providers
{
    public class UsuarioProvider
    {
        public static string Nome()
        {
            return "Tomas Oliver";
        }

        public static string Email()
        {
            return "tomas_oliver@gmail.com";
        }

        public static string Password()
        {
            return "123456";
        }

        public static string Administrador()
        {
            return "administrador";
        }
    }
}
