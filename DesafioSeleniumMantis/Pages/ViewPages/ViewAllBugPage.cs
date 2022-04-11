using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class ViewAllBugPage : PageBase
    {

        #region Mapping
        By mostrarFiltroGravidade = By.XPath("//a[@id='show_severity_filter']");
        By selecionarFiltroGravidadeComboBox = By.XPath("//td/select[@name='severity[]']");
        By mostrarFiltroPrioridade = By.XPath("//a[normalize-space()='Prioridade']");
        By selecionarFiltroPrioridadeComboBox = By.XPath("//select[@name='priority[]']");
        By mostrarFiltroCategoria = By.XPath("//a[@id='show_category_filter']");
        By selecionarFiltroCategoriaComboBox = By.XPath("//select[@name='category_id[]']");
        By mostrarFiltroRelator = By.XPath("//a[normalize-space()='Relator']");
        By selecionarFiltroRelatorComboBox = By.XPath("//select[@name='reporter_id[]']");
        By mostrarFiltroAtribuidoA = By.XPath("//a[normalize-space()='Atribuído a']");
        By selecionarFiltroAtribuidoAComboBox = By.XPath("//td/select[@name='handler_id[]']");
        By clicarEmAplicarFiltro = By.XPath("//input[@name='filter_submit']");
        By clicarEmSalvarFiltro = By.XPath("//a[normalize-space()='Salvar']");
        By carregarFiltro = By.XPath("//select[@name='source_query_id']");
        By redefinirFiltroButton = By.XPath("//a[normalize-space()='Redefinir']");
        By procurarFiltroInput = By.XPath("//input[@id='filter-search-txt']");
        By procurarFiltroPorNumeroInput = By.XPath("//input[@placeholder='Tarefa #']");
        By selecionarTudo = By.XPath("//span[@class='lbl padding-6']");
        By imprimirIssuesButton = By.XPath("//a[normalize-space()='Imprimir Tarefas']");
        By exportarCSVButton = By.XPath("//a[normalize-space()='Exportar para Arquivo CSV']");
        By exportarXLSButton = By.XPath("//a[normalize-space()='Exportação para Excel']");
        By visualizarResumoButton = By.XPath("//a[normalize-space()='Resumo']");
        By clicarEmEditarIssueComPrioridadeImediato = By.XPath("//td[normalize-space()='Teste com Prioridade Imediato']/..//a/i");
        By clicarEmEditarIssueComGravidadeObstaculo = By.XPath("//td[normalize-space()='Teste com Gravidade Obstáculo']/..//a/i");
        By clicarEmEditarIssueComAnotacao = By.XPath("//td[normalize-space()='Teste atribuir anotação']/..//a/i");
        By clicarEmVerIssueComMarcador = By.XPath("//td[normalize-space()='Teste bug com marcador']/..//td[4]");
        By retornarRelator = By.XPath("//td[@id='reporter_id_filter_target']");
        By retornarAtribuidoA = By.XPath("//td[@id='handler_id_filter_target']");
        By retornarGravidade = By.XPath("//td[@id='show_severity_filter_target']");
        By retornarPrioridade = By.XPath("//td[@id='show_priority_filter_target']");
        By retornarCategoria = By.XPath("//td[@id='show_category_filter_target']");
        By retornarBuscaPorTexto = By.XPath("//*[contains(text(), 'obstáculo')]");
        By retornarFiltroCriado = By.XPath("//select[@name='source_query_id']/option[@selected='selected']"); 
        By retornarFiltroVazio = By.XPath("//select[@name='source_query_id']/option[@value='-1']"); 


        #endregion

        #region Actions

        public void ClicarNoFiltroRelator()
        {
            Click(mostrarFiltroRelator);
        }

        public void SelecionarRelator(string relator)
        {
            ComboBoxSelectByVisibleText(selecionarFiltroRelatorComboBox, relator);
        }
        public void ClicarNoFiltroAtribuidoA()
        {
            Click(mostrarFiltroAtribuidoA);
        }

        public void SelecionarAtribuidoA(string atribuido)
        {
            ComboBoxSelectByVisibleText(selecionarFiltroAtribuidoAComboBox, atribuido);
        }
        public void ClicarNoFiltroGravidade()
        {
            Click(mostrarFiltroGravidade);
        }

        public void SelecionarGravidade(string gravidade)
        {
            ComboBoxSelectByVisibleText(selecionarFiltroGravidadeComboBox, gravidade);
        }
        public void ClicarNoFiltroPrioridade()
        {
            Click(mostrarFiltroPrioridade);
        }

        public void SelecionarPrioridade(string prioridade)
        {
            ComboBoxSelectByVisibleText(selecionarFiltroPrioridadeComboBox, prioridade);
        }
        public void ClicarNoFiltroCategoria()
        {
            Click(mostrarFiltroCategoria);
        }

        public void SelecionarCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(selecionarFiltroCategoriaComboBox, categoria);
        }
        public void PreencherTextoFiltro(String filtro)
        {
            SendKeys(procurarFiltroInput, Keys.Control + "a");
            SendKeys(procurarFiltroInput, Keys.Delete);
            SendKeys(procurarFiltroInput, filtro);
        }
        public void PreencherNumeroFiltro(String filtro)
        {
            SendKeys(procurarFiltroPorNumeroInput, filtro);
            SendKeys(procurarFiltroPorNumeroInput, Keys.Enter);
        }

        public void ClicarEmSelecionarTudo()
        {
            Click(selecionarTudo);
        }
        public void ClicarEmImprimir()
        {
            Click(imprimirIssuesButton);
        }
        public void ClicarEmExportarCSV()
        {
            Click(exportarCSVButton);
        }
        public void ClicarEmExportarXLS()
        {
            Click(exportarXLSButton);
        }
        public void ClicarEmVisualizarResumo()
        {
            Click(visualizarResumoButton);
        }

        public void ClicarEmRedefinir()
        {
            Click(redefinirFiltroButton);
        }

        public void CarregarFiltro(string nomeDoFiltro)
        {
            ComboBoxSelectByVisibleText(carregarFiltro, nomeDoFiltro);
        }

        public void ClicarEmAplicarFiltro()
        {
            Click(clicarEmAplicarFiltro);
        }
        public void ClicarEmSalvarFiltro()
        {
            Click(clicarEmSalvarFiltro);
        }
        public void ClicarEmRedefinirFiltro()
        {
            Click(redefinirFiltroButton);
        }
        public void ClicarEmEditarIssueComPrioridadeImediato()
        {
            Click(clicarEmEditarIssueComPrioridadeImediato);
        }
        public void ClicarEmEditarIssueComGravidadeObstaculo()
        {
            Click(clicarEmEditarIssueComGravidadeObstaculo);
        }
        public void ClicarEmEditarIssueSemAnotacao()
        {
            Click(clicarEmEditarIssueComAnotacao);
        }
        public void ClicarEmEditarIssueComAnotacao()
        {
            Click(clicarEmEditarIssueComAnotacao);
        }
        public void ClicarEmVerIssueComMarcador()
        {
            Click(clicarEmVerIssueComMarcador);
        }
        public string RetornarRelator()
        {
            return GetText(retornarRelator);
        }
        public string RetornarPrioridade()
        {
            return GetText(retornarPrioridade);
        }
        public string RetornarBuscaPorTexto()
        {
            return GetText(retornarBuscaPorTexto);
        }
        public string RetornarCategoria()
        {
            return GetText(retornarCategoria);
        }

        public string RetornarAtribuidoA()
        {
            return GetText(retornarAtribuidoA);
        }

        public string RetornarGravidade()
        {
            return GetText(retornarGravidade);
        }
        public string RetornarFiltroCriado()
        {
            return GetText(retornarFiltroCriado);
        }
        public string RetornarFiltroVazio()
        {
            return GetText(retornarFiltroVazio);
        }

        #endregion
        public ViewAllBugPage FiltrarPorRelator(String relator)
        {
            ClicarNoFiltroRelator();
            SelecionarRelator(relator);
            ClicarEmAplicarFiltro();

            return new ViewAllBugPage();
        }
        public ViewAllBugPage FiltrarPorAtribuidoA(String atribuido)
        {
            ClicarNoFiltroAtribuidoA();
            SelecionarAtribuidoA(atribuido);
            ClicarEmAplicarFiltro();

            return new ViewAllBugPage();
        }
        public ViewAllBugPage FiltrarPorGravidade(String gravidade)
        {
            ClicarNoFiltroGravidade();
            SelecionarGravidade(gravidade);
            ClicarEmAplicarFiltro();

            return new ViewAllBugPage();
        }
        public ViewAllBugPage FiltrarPorPrioridade(String prioridade)
        {
            ClicarNoFiltroPrioridade();
            SelecionarPrioridade(prioridade);
            ClicarEmAplicarFiltro();

            return new ViewAllBugPage();
        }
        public ViewAllBugPage FiltrarPorCategoria(String categoria)
        {
            ClicarNoFiltroCategoria();
            SelecionarCategoria(categoria);
            ClicarEmAplicarFiltro();

            return new ViewAllBugPage();
        }
        public ViewAllBugPage PreencherFiltro(String filtro)
        {
            PreencherTextoFiltro(filtro);
            ClicarEmAplicarFiltro();

            return new ViewAllBugPage();
        }
        public PrintAllBugPage ImprimirIssues()
        {
            //ClicarEmSelecionarTudo();
            ClicarEmImprimir();


            return new PrintAllBugPage();
        }
        public PrintAllBugPage ExportarIssueCSV()
        {
            ClicarEmSelecionarTudo();
            ClicarEmExportarCSV();


            return new PrintAllBugPage();
        }
        public PrintAllBugPage ExportarIssueXLS()
        {
            ClicarEmSelecionarTudo();
            ClicarEmExportarCSV();


            return new PrintAllBugPage();
        }
        public SummaryPage VerResumo()
        {
            ClicarEmSelecionarTudo();
            ClicarEmVisualizarResumo();


            return new SummaryPage();
        }
        public ViewPage BuscarIssueporNumero(String filtro)
        {
            PreencherNumeroFiltro(filtro);

            return new ViewPage();
        }
        public BugUpdatePage EditarIssueComPrioridadeImediato()
        {
            ClicarEmEditarIssueComPrioridadeImediato();

            return new BugUpdatePage();
        }
        public BugUpdatePage EditarIssueComGravidadeObstaculo()
        {
            ClicarEmEditarIssueComGravidadeObstaculo();

            return new BugUpdatePage();
        }
        public BugUpdatePage EditarIssueSemAnotação()
        {
            ClicarEmEditarIssueSemAnotacao();

            return new BugUpdatePage();
        }
        public BugUpdatePage EditarIssueComAnotacao()
        {
            ClicarEmEditarIssueComAnotacao();

            return new BugUpdatePage();
        }
        public ViewPage VisualizarIssueComMarcador()
        {
            ClicarEmVerIssueComMarcador();

            return new ViewPage();
        }
    }

}
