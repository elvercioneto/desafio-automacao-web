using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class QueryStorePage : PageBase
    {
        #region Mapping
        By nomeDoFiltroInput = By.XPath("//input[@name='query_name']");
        By salvarFiltroAtualButton = By.XPath("//input[@value='Salvar Filtro Atual']");
        By mensagemErroFiltroDuplicado = By.XPath("//*[text()='Outro filtro já tem este nome. Por favor, escolha um nome diferente para este filtro.']");
        By mensagemErroFiltroVazio = By.XPath("//*[text()='//*[text()='Você não pode armazenar um filtro sem um nome. Por favor, dê um nome a este filtro antes de salvar.']']");
        #endregion

        #region Actions


        public void PreencherNomeDoFiltro(String nomeDoFiltro)
        {
            SendKeys(nomeDoFiltroInput, nomeDoFiltro);
        }
        public void ClicarEmSalvarFiltro()
        {
            Click(salvarFiltroAtualButton);
        }
        public string RetornaMensagemDeErroFiltroDuplicado()
        {
            return GetText(mensagemErroFiltroDuplicado);
        }

        #endregion
        public ViewAllBugPage SalvarFiltro(String nomeDoFiltro)
        {
            PreencherNomeDoFiltro(nomeDoFiltro);
            ClicarEmSalvarFiltro();

            return new ViewAllBugPage();
        }
       
    }
       

}
