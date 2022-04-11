using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;

namespace DesafioSeleniumMantis.Pages
{
    public class ViewPage : PageBase
    {
        #region Mapping
        By descricaoBug = By.XPath("//td[@class='bug-description']");
        By numerodaIssueText = By.XPath("//td[@class='bug-id']");
        By mensagemDeErro1100 = By.XPath("//p[@class='bold']");
        By resumoBug = By.XPath("//td[@class='bug-description']");
        By gravidadeBug = By.XPath("//td[@class='bug-severity']");
        By prioridadeBug = By.XPath("//td[@class='bug-priority']");
        By inserirAnotacaoBug = By.XPath("//textarea[@id='bugnote_text']");
        By verAnotacaoBug = By.XPath("//td[@class='bugnote-note bugnote-public']");
        By clicarEmAdicionarAnotacao = By.XPath("//input[@value='Adicionar Anotação']");
        By clicarEmApagarMarcador = By.XPath("//i[@class='fa fa-times']");
        By clicarEmAplicarMarcador = By.XPath("//input[@value='Aplicar']");
        By alterarStatusButton = By.XPath("//input[@value='Alterar Status:']");
        By statusComboBox = By.XPath("//select[@name='new_status']");
        By clicarEmMonitorar = By.XPath("//input[@value='Monitorar']");
        By clicarEmPararDeMonitorar = By.XPath("//input[@value='Parar de Monitorar']");
        By verAnotacaoVazia = By.XPath("//textarea[@id='bugnote_text']");
        #endregion

        #region Actions
        public string RetornaDescricaoBug()
        {
            return GetText(descricaoBug);
        }
        public string RetornaNumeroBug()
        {
            return GetText(numerodaIssueText);
        }
        public string RetornaMensagemErro1100()
        {
            return GetText(mensagemDeErro1100);
        }
        public string RetornaResumoBug()
        {
            return GetText(resumoBug);
        }
        public string RetornaGravidadeBug()
        {
            return GetText(gravidadeBug);
        }

        public string RetornaPrioridadeBug()
        {
            return GetText(prioridadeBug);
        }
        public void PreencherAnotacao(String anotacao)
        {
            SendKeys(inserirAnotacaoBug, anotacao);
        }
        public void ClicarEmAdicionarAnotacao()
        {
            Click(clicarEmAdicionarAnotacao);
        }
        public void ClicarEmApagarMarcador()
        {
            Click(clicarEmApagarMarcador);
        }
        public void ClicarEmAplicarMarcador()
        {
            Click(clicarEmAplicarMarcador);
        }
        public void ClicarEmAlterarStatus()
        {
            Click(alterarStatusButton);
        }
        public void SelecionarStatus(string status)
        {
            ComboBoxSelectByVisibleText(statusComboBox, status);
        }
        public void ClicarEmMonitorarIssue()
        {
            Click(clicarEmMonitorar);
        }
        public void ClicarEmPararDeMonitorarIssue()
        {
            Click(clicarEmPararDeMonitorar);
        }

        public string RetornaAnotacaoBug()
        {
            return GetText(verAnotacaoBug);
        }
        public string RetornaAnotacaoVazia()
        {
            return GetText(verAnotacaoVazia);
        }
        #endregion
        public ViewPage InserirAnotacao(String anotacao)
        {

            PreencherAnotacao(anotacao);
            ClicarEmAdicionarAnotacao();
            return new ViewPage();
        }
        public TagAttachPage AplicarMarcador()
        {

            ClicarEmAplicarMarcador();
            return new TagAttachPage();
        }
        public BugChangeStatusPage AlterarStatus(String status)
        {
            SelecionarStatus(status);
            ClicarEmAlterarStatus();

            return new BugChangeStatusPage();
        }

    }
}