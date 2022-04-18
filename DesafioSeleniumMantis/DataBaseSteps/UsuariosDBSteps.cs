using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class UsuariosDBSteps
    {
        public static string RetornaUsuario(string username)
        {
            string query = UsuariosQueries.RetornaUsuario;

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
