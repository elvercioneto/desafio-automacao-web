using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class PrintAllBugPage : PageBase
    {
        #region Mapping
        By word2000Button = By.XPath("//i[@title='Word 2000']");
        By wordViewButton = By.XPath("//i[@title='Word View']");
        By retornarTituloPrint = By.XPath("//div[@class='center']"); //div[contains(text(),'MantisBT - Projeto ElvercioNeto')]");
        #endregion

        #region Actions


        public void ClicarEmWord2000()
        {
            Click(word2000Button);
        }
        public void ClicarEmWordView()
        {
            Click(wordViewButton);
        }
        public void MudarAba()
        {
            SendKeys(wordViewButton, Keys.PageDown);
        }
        public string RetornarTituloPrint()
        {
            return GetText(retornarTituloPrint);
        }

        #endregion
        //public TagUpdatePage AtualizarMarcador()
        //{
        //    ClicarEmAtualizarMarcador();
        //    return new TagUpdatePage();
        //}
        //public TagDeletePage ApagarMarcador()
        //{
        //    ClicarEmApagarMarcador();
        //    return new TagDeletePage();
        //}
    }
}
       


