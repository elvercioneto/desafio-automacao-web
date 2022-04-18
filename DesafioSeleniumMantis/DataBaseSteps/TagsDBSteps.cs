using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Queries;

namespace DesafioSeleniumMantis.DataBaseSteps
{
    public class TagsDBSteps
    {
        public static string RetornaMarcador(string marcador)
        {
            string query = TagsQueries.RetornaMarcador.Replace("$marcador", marcador);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }

    }
}
