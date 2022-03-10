using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class LoginPasswordPage : PageBase
    {
        #region Mapping
        By passwordField = By.Id("password");
        By loginButton = By.CssSelector("input[type=submit]");
        //By mensagemErroTextArea = By.CssSelector("div[class='alert alert-danger'] p");
        By perdeuASenhalink = By.XPath("//a[normalize-space()='Perdeu a sua senha?']");
        #endregion

        #region Actions

        public void PreencherSenha(string senha)
        {
            SendKeysJavaScript(passwordField, senha);
        }

        public void ClicarEmEntrar()
        {
            ClickJavaScript(loginButton);
        }

        public void ClicarEmPerdeuASenha()
        {
            Click(perdeuASenhalink);
        }

        #endregion
        public MyViewPage InserirPassword(string senha)
        {
            PreencherSenha(senha);
            ClicarEmEntrar();
            return new MyViewPage();
        }
        public LostPasswordPage ClicarPerdeuASenha()
        {
            ClicarEmPerdeuASenha();
            return new LostPasswordPage();
        }
    }
}
