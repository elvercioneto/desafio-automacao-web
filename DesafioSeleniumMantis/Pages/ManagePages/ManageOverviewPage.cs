using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageOverviewPage : PageBase
    {
        #region Mapping
        By gerenciarUsuariosLink = By.CssSelector("a[href='/manage_user_page.php']");
        By gerenciarProjetosLink = By.CssSelector("a[href='/manage_proj_page.php']");
        By gerenciarMarcadoresLink = By.CssSelector("a[href='/manage_tags_page.php']");
        By gerenciarCamposPersonalizadosLink = By.CssSelector("a[href='/manage_custom_field_page.php']");
        By gerenciarPerfisGlobaisLink = By.CssSelector("a[href='/manage_prof_menu_page.php']");
        By gerenciarPluginsLink = By.CssSelector("a[href='/manage_plugin_page.php']");
        By gerenciarConfiguracaoLink = By.CssSelector("a[href='/adm_permissions_report.php']");
        By clicarEmTodosOsProjetos = By.CssSelector("li[id='dropdown_projects_menu'] a[class='dropdown-toggle']");
        By clicarEmProjetoCriado = By.XPath("//a[normalize-space()='Projeto ElvercioNeto']");

        #endregion

        #region Actions


        public void ClicarEmGerenciarUsuarios()
        {
            Click(gerenciarUsuariosLink);
        }
        public void ClicarEmGerenciarProjetos()
        {
            Click(gerenciarProjetosLink);
        }
        public void ClicarEmGerenciarMarcadores()
        {
            Click(gerenciarMarcadoresLink);
        }
        public void ClicarEmGerenciarCamposPersonalizados()
        {
            Click(gerenciarCamposPersonalizadosLink);
        }
        public void ClicarEmGerenciarPerfisGlobais()
        {
            Click(gerenciarPerfisGlobaisLink);
        }
        public void ClicarEmGerenciarPlugins()
        {
            Click(gerenciarPluginsLink);
        }
        public void ClicarEmGerenciarConfiguracao()
        {
            Click(gerenciarConfiguracaoLink);
        }
        public void ClicarEmTodosOsProjetos()
        {
            Click(clicarEmTodosOsProjetos);
        }
        public void ClicarEmProjetoCriado()
        {
            Click(clicarEmProjetoCriado);
        }
        #endregion
        public ManageProjPage GerenciarProjetos()
        {
            ClicarEmGerenciarProjetos();
            return new ManageProjPage();
        }
        
        public ManageOverviewPage SelecionarProjetoCriado()
        {
            {
                ClicarEmTodosOsProjetos();
                ClicarEmProjetoCriado();
                return new ManageOverviewPage();
            }
        }
        public ManageUserPage GerenciarUsuarios()
        {
            ClicarEmGerenciarUsuarios();
            return new ManageUserPage();
        }
        public ManageTagsPage GerenciarMarcadores()
        {
            ClicarEmGerenciarMarcadores();
            return new ManageTagsPage();
        }
    }
}
