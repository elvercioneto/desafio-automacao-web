using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;


namespace DesafioSeleniumMantis.Pages
{
    public class ManageProjCatPage : PageBase
    {
        #region Mapping
        By mensagemErroTextArea = By.CssSelector(".bold");
        #endregion

        #region Actions
        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }
        
        #endregion

    }
}
