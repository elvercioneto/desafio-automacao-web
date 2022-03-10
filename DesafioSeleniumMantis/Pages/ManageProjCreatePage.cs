using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageProjCreatePage : PageBase
    {
        #region Mapping
        By nomeDoProjetoInput = By.Id("project-name");
        By estadoComboBox = By.Id("project-status");
        By visibilidadeComboBox = By.Id("project-view-state");
        By descricaoProjetoTextArea = By.Id("project-description");
        By adicionarProjetoButton = By.CssSelector("input[type='submit']");
        By mensagemErroTextArea = By.CssSelector(".bold");
        #endregion

        #region Actions

        public void PreencherNomeDoProjeto(string nomeDoProjeto)
        {
            SendKeys(nomeDoProjetoInput, nomeDoProjeto);
        }
        public void SelecionarEstado(string estado)
        {
            ComboBoxSelectByVisibleText(estadoComboBox, estado);
        }
        public void SelecionarVisibilidade(string visibilidade)
        {
            ComboBoxSelectByVisibleText(visibilidadeComboBox, visibilidade);
        }
        public void PreencherDescricao(string descricao)
        {
            SendKeys(descricaoProjetoTextArea, descricao);
        }
        public void PreencherNovaDescricao(string novaDescricao)
        {
            SendKeys(descricaoProjetoTextArea, Keys.Control + "a");
            SendKeys(descricaoProjetoTextArea, novaDescricao);

        }
        public void ClicarEmAdicionarProjeto()
        {
            Click(adicionarProjetoButton);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }

        #endregion
        public ManageProjPage PreencherDadosNovoProjeto(string nomeDoProjeto, string descricao)
        {
            PreencherNomeDoProjeto(nomeDoProjeto);
            PreencherDescricao(descricao);
            ClicarEmAdicionarProjeto();
            return new ManageProjPage();
        }

    }
}
