using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping
        By usernameField = By.Id("username");
        By loginButton = By.CssSelector("input[type=submit]");
        By mensagemErroTextArea = By.CssSelector("div[class='alert alert-danger'] p");
        By criarNovaConta = By.LinkText("criar uma nova conta");
        #endregion

        #region Actions
        public void PreencherUsuario(string usuario)
        {
            SendKeysJavaScript(usernameField, usuario);
        }

        //public void PreencherUsuario(string usuario)
        //{
        //    SendKeys(usernameField, usuario);
        //}

        public void ClicarEmLogin()
        {
            Click(loginButton);
        }

        public string RetornaTextoReajustes()
        {
            return GetText(mensagemErroTextArea);
        }

        public void ClicarEmNovaConta()
        {
            Click(criarNovaConta);
        }
        #endregion
        public LoginPasswordPage InserirLogin(string usuario)
        {
            PreencherUsuario(usuario);
            ClicarEmLogin();
            return new LoginPasswordPage();
        }
    }
}
