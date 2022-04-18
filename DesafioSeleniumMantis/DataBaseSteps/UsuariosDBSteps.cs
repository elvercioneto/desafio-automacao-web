using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class UsuariosDBSteps
    {
        public static string RetornaUsuario(string usuario)
        {
            string query = UsuariosQueries.RetornaUsuario.Replace("$usuario", usuario);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
