using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class LostPasswordPage : PageBase
    {
        #region Mapping
        By usernameField = By.Id("username");
        By emailField = By.Id("email-field");
        By loginButton = By.CssSelector("input[value = 'Enviar']");
        By mensagemEmailInvalido = By.XPath("//p[normalize-space()='E-mail inválido.']");
        //By reajusteDeSenhaTexto = By.XPath("//div[@id='main-container']//h4[1]");
        By reajusteTextoBotao = By.XPath("//a[contains(text(),'criar uma nova conta')]");
        //By reajusteDeSenhaTexto = By.XPath("//input[@value='Enviar']");
        #endregion

        #region Actions

        public void PreencherUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }
        public void PreencherEmail(string email)
        {
            SendKeys(emailField, email);
        }
        public void ClicarEmEnviar()
        {
            Click(loginButton);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemEmailInvalido);
        }
               
        #endregion
        public LoginPage ReajustarSenha(string email)
        {
            PreencherEmail(email);
            ClicarEmEnviar();
            return new LoginPage();
        }
        public LostPasswordPage ReajustarSenhaEmailVazio(string email)
        {
            PreencherEmail(email);
            ClicarEmEnviar();
            return this;
        }
        public LostPasswordPage ReajustarSenhaEmailInvalido(string email)
        {
            PreencherEmail(email);
            ClicarEmEnviar();
            return this;
        }
    }
}

