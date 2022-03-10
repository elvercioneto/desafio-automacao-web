using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class MyViewPage : PageBase
    {
        #region Mapping
        By usernameLoginInfoTextArea = By.CssSelector(".user-info");
        By verTarefasLink = By.CssSelector("a[href='/view_all_bug_page.php']");
        By criarTarefaLink = By.CssSelector("a[href = '/bug_report_page.php']");
        By registroDeMudancasLink = By.CssSelector("a[href='/changelog_page.php']");
        By planejamentoLink = By.CssSelector("a[href='/roadmap_page.php']");
        By resumoLink = By.CssSelector("a[href='/summary_page.php']");
        By gerenciarLink = By.CssSelector("a[href='/manage_overview_page.php']");
        By clicarEmTodosOsProjetos = By.CssSelector("li[id='dropdown_projects_menu'] a[class='dropdown-toggle']");
        By clicarEmProjetoElvercioNeto = By.XPath("//a[normalize-space()='Projeto ElvercioNeto']");
        By clicarEmIssuePrioridadeObstaculo = By.LinkText("Teste gravidade obstáculo");
        #endregion

        #region Actions
        public string RetornaUsuarioLogado()
        {
            return GetText(usernameLoginInfoTextArea);
        }
        public void ClicarEmGerenciar()
        {
            Click(gerenciarLink);
        }
        public void ClicarEmTodosOsProjetos()
        {
            Click(clicarEmTodosOsProjetos);
        }
        public void ClicarEmProjetoElvercioNeto()
        {
            Click(clicarEmProjetoElvercioNeto);
        }
        public void ClicarEmCriarTarefa()
        {
            Click(criarTarefaLink);
        }
        public void ClicarEmVerTarefas()
        {
            Click(verTarefasLink);
        }
        public void ClicarEmIssuePrioridadeObstaculo()
        {
            Click(clicarEmIssuePrioridadeObstaculo);
        }


        #endregion
        public ManageOverviewPage Gerenciar()
        {
            ClicarEmGerenciar();
            return new ManageOverviewPage();
        }
        public MyViewPage SelecionarProjetoElvercioNeto()
        {
            ClicarEmTodosOsProjetos();
            ClicarEmProjetoElvercioNeto();
            return  new MyViewPage();
        }

    }
}
