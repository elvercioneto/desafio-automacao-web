using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;
using MySql.Data.MySqlClient;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class ProjectsDBSteps
    {
        public static string RetornarProjeto(string projeto)
        {
            string query = "SELECT name FROM mantis_project_table ORDER BY ID DESC LIMIT 1";

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornarCategoriaDuplicada(string categoria)
        {
            string query = "SELECT name FROM mantis_category_table ORDER BY ID DESC LIMIT 1";

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
