using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageUserPage : PageBase
    {
        #region Mapping
        By criarNovaContaButton = By.LinkText("Criar nova conta");
        By filtroBuscarContaInput = By.Id("search");
        By aplicarFiltroButton = By.CssSelector("input[type='submit']");
        By perdeuASenhalink = By.LinkText("Perdeu a sua senha?");
        By clicarNoUsuarioCriado = By.CssSelector(".table tbody :nth-of-type(2) > td > a");
        #endregion

        #region Actions

        public void ClicarEmCriarNovaConta()
        {
            Click(criarNovaContaButton);
        }
        public void ClicarNoUsuarioCriado()
        {
            Click(clicarNoUsuarioCriado);
        }

        #endregion
        public ManageUserCreatePage SelecionarProjetoCriado()
        {
            {
                ClicarEmCriarNovaConta();
                return new ManageUserCreatePage();
            }
        }
        public ManageUserEditPage EscolherUsuarioCriado()
        {
            {
                ClicarNoUsuarioCriado();
                return new ManageUserEditPage();
            }
        }
    }
}
