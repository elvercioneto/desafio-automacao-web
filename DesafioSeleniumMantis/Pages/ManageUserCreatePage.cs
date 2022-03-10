using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageUserCreatePage : PageBase
    {
        #region Mapping
        By nomeUsuarioInput = By.Id("user-username");
        By nomeVerdadeiroInput = By.Id("user-realname");
        By emailInput = By.Id("email-field");
        By nivelDeAcessoComboBox = By.Id("user-access-level");
        By atribuirProjetoComboBox = By.Id("add-user-project-id");
        By criarUsuarioButton = By.CssSelector("input[type='submit']");
        By adicionarUsuarioButton = By.CssSelector("input[value='Adicionar Usuário']");
        By buttonSucessoText = By.XPath("//a[normalize-space()='Clique aqui para prosseguir']");
        By alertaErro = By.XPath("//p[contains(text(),'APPLICATION ERROR #800')]");
        #endregion

        #region Actions
        ////parei em prencher dados do novo usuario - atribuir projeto ao usuario
        public void PreencherNomeUsuario(string nomeUsuario)
        {
            SendKeys(nomeUsuarioInput, nomeUsuario);
        }
        public void PreencherNomeVerdadeiro(string nomeVerdadeiro)
        {
            SendKeys(nomeVerdadeiroInput, nomeVerdadeiro);
        }
        public void PreencherEmail(string email)
        {
            SendKeys(nomeUsuarioInput, email);
        }
        public void AtribuirProjetoAoUsuario(string projeto)
        {
            ComboBoxSelectByVisibleText(atribuirProjetoComboBox, projeto);
        }

        public void ClicarEmCriarUsuario()
        {
            Click(criarUsuarioButton);
        }

        public void ClicarEmAdicionarUsuario()
        {
            Click(adicionarUsuarioButton);
        }
        public string RetornaAlertaDeSucesso()
        {
            return GetText(buttonSucessoText);
        }
        public string RetornaAlertaDeErro()
        {
            return GetText(alertaErro);
        }

        #endregion
        public ManageUserCreatePage CriarNovoUsuario(String nomeUsuario)
        {
            {
                PreencherNomeUsuario(nomeUsuario);
                ClicarEmCriarUsuario();
                return new ManageUserCreatePage();
            }
        }
    }
}
