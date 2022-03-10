using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageProjEditPage : PageBase
    {
        #region Mapping
        By criarNovoProjetoButton = By.XPath("//button[normalize-space()='Criar Novo Projeto']");
        By adicionarCategoriaInput = By.CssSelector("input[name='name']");
        By adicionarCategoriaButton = By.CssSelector("input[value='Adicionar Categoria']");
        By descricaoProjetoTextArea = By.Id("project-description");
        By adicionarProjetoButton = By.CssSelector("input[type='submit']");
        #endregion

        #region Actions

        public void ClicarEmCriarNovoProjeto()
        {
            Click(criarNovoProjetoButton);
        }
        public void PreencherCategoria(string categoria)
        {
            SendKeys(adicionarCategoriaInput, categoria);
        }

        public void ClicarEmAdicionarCategoria()
        {
            Click(adicionarCategoriaButton);
        }
        public void PreencherNovaDescricao(string novaDescricao)
        {
            SendKeys(descricaoProjetoTextArea, Keys.Control + "a");
            SendKeys(descricaoProjetoTextArea, novaDescricao);

        }
        public void ClicarEmAlterarProjeto()
        {
            Click(adicionarProjetoButton);
        }

        #endregion
        public ManageProjPage CriarCategoria(string categoria)
        {
            PreencherCategoria(categoria);
            ClicarEmAdicionarCategoria();
            return new ManageProjPage();
        }
        public ManageProjCatPage CriarCategoriaCampoVazio(string categoria)
        {
            PreencherCategoria(categoria);
            ClicarEmAdicionarCategoria();
            return new ManageProjCatPage();
        }
        public ManageProjCreatePage CriarNovoProjeto()
        {
            ClicarEmCriarNovoProjeto();
            return new ManageProjCreatePage();
        }


    }
}
