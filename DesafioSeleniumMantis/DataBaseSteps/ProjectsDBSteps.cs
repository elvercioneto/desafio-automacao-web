using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class ProjectsDBSteps
    {
       
        public static string RetornaCategoriaDuplicada(string categoria)
        {
            string query = ProjectsQueries.RetornaCategoriaDuplicada.Replace("$categoria", categoria);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
