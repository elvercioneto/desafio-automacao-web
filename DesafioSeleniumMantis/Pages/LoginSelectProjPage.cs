using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class LoginSelectProjPage : PageBase
    {
        #region Mapping
        By selecionarProjetoComboBox = By.XPath("//select[@id='select-project-id']");
        By selecionarProjetoButton = By.XPath("//input[@value='Selecionar Projeto']");
        By loginButton = By.CssSelector("input[value = 'Entrar']");
        By mensagemErroTextArea = By.CssSelector("div[class='alert alert-danger'] p");
        By criarNovaConta = By.LinkText("criar uma nova conta");
        #endregion

        #region Actions

        public  void SelecionarProjeto(string projeto)
        {
            ComboBoxSelectByVisibleText(selecionarProjetoComboBox, projeto);
        }
        public void ClicarEmSelecionarProjeto()
        {
            Click(selecionarProjetoButton);
        }

       

        #endregion
        public BugReportPage EscolherProjeto(string projeto)
        {
            SelecionarProjeto(projeto);
            ClicarEmSelecionarProjeto();
            return new BugReportPage();
        }
    }
}
