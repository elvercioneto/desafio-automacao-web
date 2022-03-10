using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class TagViewPage: PageBase
    {
        #region Mapping
        By atualizarMarcadorButton = By.XPath("//input[@value='Atualizar Marcador']");
        By apagarMarcadorButton = By.XPath("//input[@value='Apagar Marcador']");
       
        #endregion

        #region Actions
      

        public void ClicarEmAtualizarMarcador()
        {
            Click(atualizarMarcadorButton);
        }
        public void ClicarEmApagarMarcador()
        {
            Click(apagarMarcadorButton);
        }

        //public string RetornaMarcadorCriado()
        //{
        //    return GetText(escolherMarcadorCriado);
        //}

        #endregion
        public TagUpdatePage AtualizarMarcador()
        {
            ClicarEmAtualizarMarcador();
            return new TagUpdatePage();
        }
        public TagDeletePage ApagarMarcador()
        {
            ClicarEmApagarMarcador();
            return new TagDeletePage();
        }
    }
       

}
