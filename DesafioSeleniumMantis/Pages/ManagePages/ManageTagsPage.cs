using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageTagsPage : PageBase
    {
        #region Mapping
        By nomeMarcadorInput = By.XPath("//input[@id='tag-name']");
        By criarMarcadorButton = By.XPath(" //input[@name='config_set']");
        By escolherMarcadorCriado = By.XPath("//a[normalize-space()='release1']");
        By escolherMarcadorAtualizado = By.XPath("//a[contains(text(),'teste')]");

        #endregion

        #region Actions
        public void PreencherNomeMarcador(string marcador)
        {
            SendKeys(nomeMarcadorInput, marcador);
        }

        public void ClicarEmCriarMarcador()
        {
            Click(criarMarcadorButton);
        }
        public void ClicarEmMarcadorCriado(String marcador)
        {
            Click(escolherMarcadorCriado);
        }
        public void ClicarEmMarcadorAtualizado(String marcador)
        {
            Click(escolherMarcadorAtualizado);
        }
        public string RetornaMarcadorCriado()
        {
            return GetText(escolherMarcadorCriado);
        }

        #endregion
        public ManageTagsPage CriarMarcador(string marcador)
        {
            PreencherNomeMarcador(marcador);
            ClicarEmCriarMarcador();
            return new ManageTagsPage();
        }

        public TagViewPage ClicarNoMarcadorCriado(String marcador)
        {
            ClicarEmMarcadorCriado(marcador);
            return new TagViewPage();
        }
        public TagViewPage ClicarNoMarcadorAtualziado(String marcador)
        {
            ClicarEmMarcadorCriado(marcador);
            return new TagViewPage();
        }
    }
       

}
