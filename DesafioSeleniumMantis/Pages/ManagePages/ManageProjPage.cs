using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ManageProjPage : PageBase
    {
        #region Mapping
        By criarNovoProjetoButton = By.XPath("//button[normalize-space()='Criar Novo Projeto']");
        By adicionarCategoriaInput = By.CssSelector("input[name='name']");
        By adicionarCategoriaButton = By.CssSelector("input[value='Adicionar Categoria']");
        By projetoCriado = By.XPath("//td//a[contains(text(),'Projeto ElvercioNeto')]");
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
        public void ClicarEmProjetoCriado()
        {
            Click(projetoCriado);
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
