using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;
using MySql.Data.MySqlClient;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class UsuariosDBSteps
    {
        public static string RetornaUsuario(string username)
        {
            string query = "SELECT username FROM mantis_user_table WHERE id=1";

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
        public static string RetornaUsuarioRepetido(string username)
        {
            string query = "SELECT username FROM mantis_user_table ORDER BY ID DESC LIMIT 1";

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
        public static string RetornaMarcador(string marcador)
        {
            string query = "SELECT NAME FROM mantis_tag_table ORDER BY ID DESC LIMIT 1";
            //string query = UsersQueries.RetornaUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        

        //SELECT* FROM mantis_user_table WHERE id=1
        //SELECT username FROM mantis_user_table ORDER BY ID DESC LIMIT 1
    }
}
