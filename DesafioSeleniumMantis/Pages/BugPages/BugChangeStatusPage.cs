using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;

namespace DesafioSeleniumMantis.Pages
{
    public class BugChangeStatusPage : PageBase
    {
        #region Mapping
        By admitirTarefaButton = By.XPath("//input[@value='Admitir Tarefa']");
        By fecharTarefaButton = By.XPath("//input[@value='Fechar Tarefa']");

        #endregion

        #region Actions
        public void ClicarEmAdmitirTarefa()
        {
             Click(admitirTarefaButton);
        }
        public void ClicarEmFecharTarefa()
        {
            Click(fecharTarefaButton);
        }
        #endregion
        public ViewPage AdmitirTarefa()
        {
            ClicarEmAdmitirTarefa();
            return new ViewPage();
        }
        public ViewPage FecharTarefa()
        {
            ClicarEmFecharTarefa();
            return new ViewPage();
        }
    }
}