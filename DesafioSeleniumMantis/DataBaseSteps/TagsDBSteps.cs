using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class TagsDBSteps
    {
        public static string RetornaMarcador(string tag)
        {
            string query = TagsQueries.RetornaMarcador;

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
