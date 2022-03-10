using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;

namespace DesafioSeleniumMantis.Pages
{
    public class BugNoteDeletePage : PageBase
    {
        #region Mapping
        By apagarAnotacaoButton = By.XPath("//input[@value='Apagar Anotação']");
        #endregion

        #region Actions
        public void ClicarEmApagarAnotacao()
        {
            Click(apagarAnotacaoButton);
        }
        #endregion
        public ViewPage ApagarAnotacao()
        {
            ClicarEmApagarAnotacao();
            return new ViewPage();
        }
    }
}