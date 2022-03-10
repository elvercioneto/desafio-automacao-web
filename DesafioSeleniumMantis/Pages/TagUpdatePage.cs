using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class TagUpdatePage : PageBase
    {
        #region Mapping
        By nomeMarcadorInput = By.XPath("//input[@id='tag-name']");
        By atualizarMarcadorButton = By.XPath("//input[@value='Atualizar Marcador']");
        By escolherMarcadorAtualizado = By.XPath("//td[normalize-space()='release2']");
       
        #endregion

        #region Actions
        public void AtualizarNomeMarcador(string marcador)
        {
            SendKeys(nomeMarcadorInput, Keys.Control + "a");
            SendKeys(nomeMarcadorInput, Keys.Delete);

            SendKeys(nomeMarcadorInput, marcador);
        }

        public void ClicarEmAtualizarMarcador()
        {
            Click(atualizarMarcadorButton);
        }
        public string RetornaMarcadorAtualizado()
        {
            return GetText(escolherMarcadorAtualizado);
        }

        #endregion
        public TagViewPage AtualizarMarcador(string marcador)
        {
            AtualizarNomeMarcador(marcador);
            ClicarEmAtualizarMarcador();

            return new TagViewPage();
        }
    }
       

}
