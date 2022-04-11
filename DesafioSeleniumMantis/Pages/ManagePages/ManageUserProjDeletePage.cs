using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageUserProjDeletePage : PageBase
    {
        #region Mapping
        By removerUsuarioButton = By.CssSelector("input[value='Remover Usuário']");
        #endregion

        #region Actions

        public void ClicarEmRemoverUsuario()
        {
            Click(removerUsuarioButton);
        }
        #endregion
        public ManageUserEditPage ConfirmarRemoverUsuario()
        {
            {
                ClicarEmRemoverUsuario();
                return new ManageUserEditPage();
            }
        }
        
    }
}
