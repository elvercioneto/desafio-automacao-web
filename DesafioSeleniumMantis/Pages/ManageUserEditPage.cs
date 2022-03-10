using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageUserEditPage : PageBase
    {
        #region Mapping
        By atribuirProjetoComboBox = By.Id("add-user-project-id");
        By adicionarUsuarioButton = By.CssSelector("input[value='Adicionar Usuário']");
        By mensagemDeErroText = By.CssSelector("p[class='bold']");
        By removerUsuarioButton = By.CssSelector("input[value='Remover']");
        #endregion

        #region Actions
        ////parei em prencher dados do novo usuario - atribuir projeto ao usuario
        public void AtribuirProjetoAoUsuario(string projeto)
        {
            ComboBoxSelectByVisibleText(atribuirProjetoComboBox, projeto);
        }

        public void ClicarEmAdicionarUsuarioAoProjeto()
        {
            Click(adicionarUsuarioButton);
        }
        public void ClicarEmRemoverUsuarioDoProjeto()
        {
            Click(removerUsuarioButton);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemDeErroText);
        }

        #endregion
        public ManageUserEditPage AtribuirUsuarioAoProjeto(String nomeProjeto)
        {
            {
                AtribuirProjetoAoUsuario(nomeProjeto);
                ClicarEmAdicionarUsuarioAoProjeto();
                return new ManageUserEditPage();
            }
        }
        public ManageUserProjDeletePage RemoverUsuarioDoProjeto()
        {
            {
                ClicarEmRemoverUsuarioDoProjeto();
                return new ManageUserProjDeletePage();
            }
        }
    }
}
