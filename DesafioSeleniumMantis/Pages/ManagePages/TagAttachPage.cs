using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;

namespace DesafioSeleniumMantis.Pages
{
    public class TagAttachPage : PageBase
    {
        #region Mapping
        By mensagemErro = By.XPath("//p[@class='bold']");

        #endregion

        #region Actions
        public string RetornaMensagemErro()
        {
            return GetText(mensagemErro);
        }
        #endregion
    }
}