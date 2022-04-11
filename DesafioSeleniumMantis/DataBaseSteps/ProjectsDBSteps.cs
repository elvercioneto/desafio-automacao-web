using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class ProjectsDBSteps
    {
       
        public static string RetornaCategoriaDuplicada(string category)
        {
            string query = ProjectsQueries.RetornaCategoriaDuplicada.Replace("$category", category);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
