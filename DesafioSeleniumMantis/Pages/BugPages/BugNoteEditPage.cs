using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;

namespace DesafioSeleniumMantis.Pages
{
    public class BugNoteEditPage : PageBase
    {
        #region Mapping
        By anotacaoTextArea = By.XPath("//textarea[@id='bugnote_text']");
        By atualizarInformacaoButton = By.XPath("//input[@value='Atualizar Informação']");
        #endregion

        #region Actions
        public void PreencherAnotacao(String anotacao)
        {
            SendKeys(anotacaoTextArea, Keys.Control + "a");
            SendKeys(anotacaoTextArea, anotacao);
        }
        public void ClicarEmAtualizarAnotacao()
        {
            Click(atualizarInformacaoButton);
        }
        #endregion
        public ViewPage AtualizarAnotacao(String anotacao)
        {
            PreencherAnotacao(anotacao);
            ClicarEmAtualizarAnotacao();
            return new ViewPage();
        }
    }
}