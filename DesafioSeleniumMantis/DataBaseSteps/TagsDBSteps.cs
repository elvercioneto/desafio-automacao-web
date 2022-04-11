using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class TagsDBSteps
    {
        public static string RetornaMarcador(string tag)
        {
            //string query = "SELECT NAME FROM mantis_tag_table ORDER BY ID DESC LIMIT 1";
            string query = TagsQueries.RetornaMarcador.Replace("$tag", tag);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
