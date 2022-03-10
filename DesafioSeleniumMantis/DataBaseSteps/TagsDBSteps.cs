using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;
using MySql.Data.MySqlClient;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class TagsDBSteps
    {
        public static string RetornaMarcador(string marcador)
        {
            string query = "SELECT NAME FROM mantis_tag_table ORDER BY ID DESC LIMIT 1";
            //string query = UsersQueries.RetornaUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
